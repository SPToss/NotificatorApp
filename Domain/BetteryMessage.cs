using NotificatorApp.Domain.Enums;

namespace NotificatorApp.Domain
{
    public class BetteryMessage
    {
        BateryStatus BateryStatus { get; set; }
        BatteryPowerSource BatteryPowerSource { get; set; }
        int BatteryLevel { get; set; }
    }
}