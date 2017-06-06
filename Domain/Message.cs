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
using NotificatorApp.Domain.Enums;

namespace NotificatorApp.Domain
{
    public class Message
    {
        public string Text { get; set; }

        public Status MessageStatus { get; set; }
        
        public Source MessageSource { get; set; }

    }
}