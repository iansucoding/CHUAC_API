using System.Collections.Generic;

namespace CHUACSystem.Data.Models
{
    public class HostGroup : BaseEntity
    {
        public string Name { get; set; }

        public List<Host> Hosts { get; set; }
        public List<HostSchedule> HostSchedules { get; set; }
    }
}
