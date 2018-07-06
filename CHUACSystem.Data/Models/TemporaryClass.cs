using System;

namespace CHUACSystem.Data.Models
{
    public class TemporaryClass: BaseEntity
    {
        public DateTime Date { get; set; }
        public int Times { get; set; }
        public string Classroom { get; set; }
        public string Sections { get; set; }
        public string Remark { get; set; }
    }
}
