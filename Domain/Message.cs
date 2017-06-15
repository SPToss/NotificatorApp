using Newtonsoft.Json;

namespace NotificatorApp.Domain
{
    public abstract class Message
    {
        public override string ToString()
        {
           return JsonConvert.SerializeObject(this);
        }
    }
}