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

namespace NotificatorApp.Domain.Stages
{
    public class CheckSmsStage : Stage
    {
        SmsMessagesManager _manager;
        public CheckSmsStage(string propertie) : base(propertie)
        {
            _manager = new SmsMessagesManager();
        }

        public override ServiceMessage RunStage()
        {
            return new ServiceMessage();
        }
    }
}