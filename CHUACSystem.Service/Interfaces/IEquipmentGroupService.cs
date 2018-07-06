using CHUACSystem.Data.Models;
using CHUACSystem.Service.ViewModels;
using System.Collections.Generic;

namespace CHUACSystem.Service.Interfaces
{
    public interface IEquipmentGroupService: IGenericService<EquipmentGroup, EquipmentGroupView, EquipmentGroupBase>
    {
        IEnumerable<EquipmentGroupView> GetAllEquipments();
    }
}
