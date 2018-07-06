using System.Collections.Generic;

namespace CHUACSystem.Data.Models
{
    public class EquipmentGroup: BaseEntity
    {
        public string Name { get; set; }
        public int Seq { get; set; }

        public IEnumerable<Equipment> Equipments { get; set; }
    }
}
