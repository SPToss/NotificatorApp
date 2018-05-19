using System;
using NotificatorApp.Domain.Enums;


namespace NotificatorApp.Domain.Stages
{
    public class CheckBateryStage : Stage
    {
        private bool _sendBatteryAllert;
        private bool _trackBattery;
        private int _allertLevel;
        private BatteryControlManager _manager;

        public CheckBateryStage(string preference) : base(preference)
        {
            _sendBatteryAllert = Preference.GetBoolean("Pref_battery_allert", false);
            _allertLevel = Int32.Parse(Preference.GetString("Pref_battery_allert_level", "0"));
            _trackBattery = Preference.GetBoolean("Pref_battery_track", false);
            _manager = new BatteryControlManager();
        }

        public override ServiceMessage RunStage()
        {
            var battery = _manager.GetBatteryStatus();
            ServiceMessage serviceMessage = new ServiceMessage(battery.ToString(), Source.Batery);
            if (_sendBatteryAllert && _allertLevel >= battery.BatteryLevel)
            {
                serviceMessage.MessageStatus = Status.Error;
            }
            else
            {
                serviceMessage.MessageStatus = Status.Info;
            }
            return serviceMessage;
        }
    }
}