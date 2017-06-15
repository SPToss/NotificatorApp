using NotificatorApp.Domain.Enums;

namespace NotificatorApp.Domain
{
    public class BatteryMessage : Message
    {
        public BateryStatus BateryStatus { get; set; }
        public BatteryPowerSource BatteryPowerSource { get; set; }
        public int BatteryLevel { get; set; }
    }
}
