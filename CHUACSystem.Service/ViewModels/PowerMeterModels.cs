using System;

namespace CHUACSystem.Service.ViewModels
{
    public class PowerMeterBM
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
    public class PowerMeterVM : PowerMeterBM
    {
        public long Id { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
