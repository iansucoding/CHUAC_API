using System;
using System.Collections.Generic;

namespace CHUACSystem.Service.ViewModels
{
    public class ClassroomGroupBase
    {
        public string ClassroomGroupName { get; set; }
        public int ClassroomGroupSeq { get; set; }
        public string ClassroomGroupImage { get; set; }
    }
    public class ClassroomGroupView: ClassroomGroupBase
    {
        public long ClassroomGroupId { get; set; }
        public IEnumerable<ClassroomView> Classrooms { get; set; }
    }
    public class ClassroomBase
    {
        public string ClassroomName { get; set; }
        public int ClassroomSeq { get; set; }
        public bool IsAcOn { get; set; }
        public bool? IsAuto { get; set; }
    }
    public class ClassroomView: ClassroomBase
    {
        public long ClassroomId { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
