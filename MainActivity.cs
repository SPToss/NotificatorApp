using Android.App;
using Android.Widget;
using Android.OS;
using Android.Preferences;
using Android.Content;
using NotificatorApp.Activities;
using System;
using NotificatorApp.Service;

namespace NotificatorApp
{
    [Activity(Label = "NotificatorApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
#region Buttons events
            Button settingButton = FindViewById<Button>(Resource.Id.settingsButton);
            settingButton.Click += OnSettingButtonClick;

            Button startServiceButton = FindViewById<Button>(Resource.Id.startServiceButton);
            startServiceButton.Click += OnStartServiceButtonClick;
#endregion

        }

        void OnSettingButtonClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.ApplicationContext, typeof(SettingsActivity));
            StartActivity(intent);
        }

        void OnStartServiceButtonClick(object sender, EventArgs e)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            var t = prefs.GetString("Pref_key_send_information_time_interval","0");

            Intent intent = new Intent(this.ApplicationContext, typeof(BackgroundService));
            StartService(intent);
        }
    }
}

