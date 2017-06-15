using NotificatorApp.Domain.Enums;

namespace NotificatorApp.Domain
{
    public class ServiceMessage : Message
    {
        public string Text { get; set; }

        public Status MessageStatus { get; set; }
        
        public Source MessageSource { get; set; }

        public ServiceMessage()
        {

        }

        public ServiceMessage(string text)
        {
            Text = text;
        }

        public ServiceMessage(string text, Source source) : this(text)
        {
            MessageSource = source;
        }

        public ServiceMessage(string text, Status status) : this(text)
        {
            MessageStatus = status;
        }

        public ServiceMessage(Status status, Source source) : this(string.Empty, status, source) { }

        public ServiceMessage(string text, Status status, Source source)
        {
            MessageSource = source;
            MessageStatus = status;
            Text = text;
        }
    }
}