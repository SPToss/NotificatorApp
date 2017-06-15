using Android.App;
using Android.Content;
using Android.Preferences;

namespace NotificatorApp.Domain.Stages
{
    public abstract class Stage : IStage
    {
        private string _properties;
        protected ISharedPreferences Preference;
        public Stage(string properties)
        {
            _properties = properties;
            Preference = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
        }

        public abstract ServiceMessage RunStage();

        public virtual bool CanRunStage() => Preference.GetBoolean(_properties, false);

    }
}