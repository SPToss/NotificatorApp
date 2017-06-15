using System.Collections.Generic;
using System.Linq;
using NotificatorApp.Domain.Stages;

namespace NotificatorApp.Domain
{
    public class ServiceManager
    {
        private List<IStage> _stages;

        public ServiceManager()
        {
            _stages = new List<IStage>
            {
                new CheckBateryStage("Pref_battery_track"),
                new CheckSmsStage("Pref_sms_track")
            };
        }
        public IEnumerable<ServiceMessage> GetMessages()
        {
            foreach(var stage in _stages.Where(x => x.CanRunStage()))
            {
                yield return stage.RunStage();
            }
        }
    }
}