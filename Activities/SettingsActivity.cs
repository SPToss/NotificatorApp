using Android.App;
using Android.OS;
using Android.Preferences;
using Android.Content.PM;
using static Android.Preferences.Preference;

namespace NotificatorApp.Activities
{
    [Activity(Label = "SETTINGS", ScreenOrientation = ScreenOrientation.Portrait)]
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
                UncheckPreference("Pref_battery_allert");
            }
        }

        private void UncheckPreference(string preference)
        {
            var checkp = PreferenceScreen.FindPreference(preference) as CheckBoxPreference;
            checkp.Checked = false;
        }

    }
}