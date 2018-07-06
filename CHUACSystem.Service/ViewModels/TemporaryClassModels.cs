using System;

namespace CHUACSystem.Service.ViewModels
{
    public class TemporaryClassBase
    {
        public DateTime Date { get; set; }
        public int Times { get; set; }
        public string Classroom { get; set; }
        public string Sections { get; set; }
        public string Remark { get; set; }
    }
    public class TemporaryClassView : TemporaryClassBase
    {
        public long Id { get; set; }
        public DateTime AddedOn { get; set; }
    }
}
