using System;
using System.Globalization;

namespace NotificatorApp.Domain
{
    public class SmsMessage : Message
    {
        public string Id { get; private set; }
        public string From { get; private set; }
        public string Text { get; private set; }

        public SmsMessage(string Id, string From, string Text)
        {
            this.Id = Id;
            this.From = From;
            this.Text = Text;
        }
    }
}