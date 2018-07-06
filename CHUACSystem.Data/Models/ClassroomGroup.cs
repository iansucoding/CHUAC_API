using System.Collections.Generic;

namespace CHUACSystem.Data.Models
{
    public class ClassroomGroup : BaseEntity
    {
        public string Name { get; set; }
        public int Seq { get; set; }
        public string Image { get; set; }
        public List<Classroom> Classrooms { get; set; }
    }
}
