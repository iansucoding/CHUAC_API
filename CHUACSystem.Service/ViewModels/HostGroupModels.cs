using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CHUACSystem.Service.ViewModels
{
    public class HostGroupBM
    {

    }
    public class HostGroupVM : HostGroupBM
    {
        public long HostGroupId { get; set; }
        public string HostGroupName { get; set; }
        public IEnumerable<HostVM> Hosts { get; set; }
        public IEnumerable<HostScheduleVM> HostSchedules { get; set; }
    }

    public class HostVM
    {
        public long HostId { get; set; }
        public string HostName { get; set; }
        public string HostHeaderName { get; set; }
        public bool Enable { get; set; }
        public bool Week0 { get; set; }
        public bool Week1 { get; set; }
        public bool Week2 { get; set; }
        public bool Week3 { get; set; }
        public bool Week4 { get; set; }
        public bool Week5 { get; set; }
        public bool Week6 { get; set; }
    }

    public class HostScheduleVM
    {
        public long HostScheduleId { get; set; }
        public string HostScheduleName { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string Week0 { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string Week1 { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string Week2 { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string Week3 { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string Week4 { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string Week5 { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string Week6 { get; set; }
    }
}
