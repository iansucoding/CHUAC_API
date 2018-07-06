using System.ComponentModel.DataAnnotations;

namespace CHUACSystem.Data.Models
{
    public class HostSchedule: BaseEntity
    {
        public string Name { get; set; }
        public long HostGroupId { get; set; }
        public HostGroup HostGroup { get; set; }
        [MaxLength(8)]
        public string Week0 { get; set; }
        [MaxLength(8)]
        public string Week1 { get; set; }
        [MaxLength(8)]
        public string Week2 { get; set; }
        [MaxLength(8)]
        public string Week3 { get; set; }
        [MaxLength(8)]
        public string Week4 { get; set; }
        [MaxLength(8)]
        public string Week5 { get; set; }
        [MaxLength(8)]
        public string Week6 { get; set; }
    }
}
