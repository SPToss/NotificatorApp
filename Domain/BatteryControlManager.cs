using System;
using Android;
using Android.Content;
using Android.App;
using Android.OS;
using BatteryStatus = Android.OS.BatteryStatus;
using NotificatorApp.Domain.Enums;

namespace NotificatorApp.Domain
{
    public class BatteryControlManager 
    {
        private int PercentRemaining => GetPercentRemaing();

        private BateryStatus StatusOfBattery => GetBateryStatus();

        private BatteryPowerSource PowerSourceOfBattery => GetBatteryPowerSource();

        public BatteryMessage GetBatteryStatus()
        {
            return new BatteryMessage
            {
                BateryStatus = StatusOfBattery,
                BatteryLevel = PercentRemaining,
                BatteryPowerSource = PowerSourceOfBattery
            };
        }



        private int GetPercentRemaing()
        {
            using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
            {
                using (var battery = Application.Context.RegisterReceiver(null, filter))
                {
                    var level = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
                    var scale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);
                    return (int)Math.Floor(level * 100D / scale);
                }
            }
        }

        private BateryStatus GetBateryStatus()
        {
            using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
            {
                using (var battery = Application.Context.RegisterReceiver(null, filter))
                {
                    int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);

                    switch (status)
                    {
                        case (int)BatteryStatus.Charging:
                            return BateryStatus.Charging;
                        case (int)BatteryStatus.Discharging:
                            return BateryStatus.Discharging;
                        case (int)BatteryStatus.Full:
                            return BateryStatus.Full;
                        case (int)BatteryStatus.NotCharging:
                            return BateryStatus.NotCharging;
                        default:
                            return BateryStatus.Unknown;
                    }
                }
            }
        }

        private BatteryPowerSource GetBatteryPowerSource()
        {
            using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
            {
                using (var battery = Application.Context.RegisterReceiver(null, filter))
                {
                    var status = GetBateryStatus();
                    if(status == BateryStatus.Charging || status == BateryStatus.Full)
                    {
                        var chargeType = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                        switch (chargeType)
                        {
                            case (int)BatteryPlugged.Usb:
                                return BatteryPowerSource.Usb;
                            case (int)BatteryPlugged.Ac:
                                return BatteryPowerSource.Ac;
                            case (int)BatteryPlugged.Wireless:
                                return BatteryPowerSource.Wireless;
                            default:
                                return BatteryPowerSource.Other;
                        }
                    }
                    return BatteryPowerSource.Battery;
                }
            }
        }
    }
}