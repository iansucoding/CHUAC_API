using System;
using System.Collections.Generic;

namespace CHUACSystem.Service.ViewModels
{
    public class EquipmentGroupBase
    {
        public string EquipmentGroupName { get; set; }
        public int EquipmentGroupSeq { get; set; }

    }
    public class EquipmentGroupView : EquipmentGroupBase
    {
        public long EquipmentGroupId { get; set; }
        public IEnumerable<EquipmentView> Equipments { get; set; }
    }

    public class EquipmentBase
    {
        public string EquipmentName { get; set; }
        public int EquipmentSeq { get; set; }
        public string Desc { get; set; }
        public double Value { get; set; }
    }
    public class EquipmentView : EquipmentBase
    {
        public long EquipmentId { get; set; }
        public string ModifiedOn { get; set; }
    }
}
