using System;
using System.Collections.Generic;
using System.Text;

namespace CHUACSystem.Data.Models
{
    public class TemperatureHistory: BaseEntity
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
