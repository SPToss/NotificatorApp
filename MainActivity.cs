using Android.App;
using Android.Widget;
using Android.OS;
using Android.Preferences;
using Android.Content;
using NotificatorApp.Activities;
using System;

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
            Button button = FindViewById<Button>(Resource.Id.settingsButton);
            button.Click += OnButtonClicked;

        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.ApplicationContext, typeof(SettingsActivity));
            StartActivity(intent);
        }
    }
}

