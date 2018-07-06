using System;

namespace CHUACSystem.Service.ViewModels
{
    public class TemperatureHistoryBase
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
    public class TemperatureHistoryView : TemperatureHistoryBase
    {
        public DateTime AddedOn { get; set; }
    }
}
