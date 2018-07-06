namespace CHUACSystem.Data.Models
{
    public class EventLog : BaseEntity
    {
        public string SystemName { get; set; }
        public string EventType { get; set; }
        public string Content { get; set; }
    }
}
