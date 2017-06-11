using Android.Preferences;

namespace NotificatorApp.Domain.Stages
{
    public class CheckBateryStage : IStage
    {
        public ServiceMessage RunStage()
        {
            return new ServiceMessage();
            //var checkp = PreferenceScreen.FindPreference(preference) as CheckBoxPreference;
        }
    }
}