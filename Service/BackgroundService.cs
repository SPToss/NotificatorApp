using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using Android.Preferences;

namespace NotificatorApp.Service
{
    [Service]
    public class BackgroundService : Android.App.Service
    {
        Timer timer;
        DateTime startTime;
        bool isStarted = false;

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override IBinder OnBind(Intent intent)
        {
            // This is a started service, not a bound service, so we just return null.
            return null;
        }


        public override void OnDestroy()
        {
            timer.Dispose();
            timer = null;
            isStarted = false;
            base.OnDestroy();
        }

        void HandleTimerCallback(object state)
        {



            var myHandler = new Handler(Looper.MainLooper);


            myHandler.Post(() => {
                Toast.MakeText(this, "Message from demo service", ToastLength.Long).Show();
            });

        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if (isStarted)
            {
                TimeSpan runtime = DateTime.UtcNow.Subtract(startTime);
            }
            else
            {
                var prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                var timeToWait = Int32.Parse(prefs.GetString("Pref_key_send_information_time_interval", "0"));
                timer = new Timer(HandleTimerCallback, DateTime.UtcNow, 0, timeToWait);
                isStarted = true;
            }
            return StartCommandResult.NotSticky;
        }

    }
}