using System;

namespace CHUACSystem.Service.ViewModels
{
    public class EventLogBase
    {
        public string SystemName { get; set; }
        public string EventType { get; set; }
        public string Content { get; set; }
    }
    public class EventLogView : EventLogBase
    {
        public long Id { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
