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
using Android.Preferences;
using Android.Content.PM;
using static Android.Preferences.Preference;

namespace NotificatorApp.Activities
{
    [Activity(Label = "TEST", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SettingsActivity : PreferenceActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AddPreferencesFromResource(Resource.Xml.Preference);

            #region Preference events
            var prefBatteryTrack = PreferenceScreen.FindPreference("Pref_battery_track");
            prefBatteryTrack.PreferenceChange += PrefBatteryTrackChange;
            #endregion

        }

        protected override void OnStart()
        {
            base.OnStart();

        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        private void PrefBatteryTrackChange(object sender, PreferenceChangeEventArgs e)
        {
            if (!(bool)e.NewValue)
            {
                var checkp = PreferenceScreen.FindPreference("Pref_battery_track_status") as CheckBoxPreference;
                checkp.Checked = false;
            }
        }
    }
}