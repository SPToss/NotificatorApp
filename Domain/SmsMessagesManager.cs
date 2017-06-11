using System.Collections.Generic;
using Android.App;

namespace NotificatorApp.Domain
{
    public class SmsMessagesManager
    {
        public List<SmsMessage> GetAllUnreadSmsMessages()
        {           
            var cursor = Application.Context.ContentResolver.Query(Android.Net.Uri.Parse("content://sms/inbox"), new string[] { "_id", "address", "body" }, "read=0", null, null);
            List<SmsMessage> messages = new List<SmsMessage>();
            while (cursor.MoveToNext())
            {
                var address = cursor.GetString(cursor.GetColumnIndex("address"));
                var body = cursor.GetString(cursor.GetColumnIndex("body"));
                var id = cursor.GetString(cursor.GetColumnIndex("_id"));
                messages.Add(new SmsMessage(id, address, body));
            }
            return messages;
        }
    }
}