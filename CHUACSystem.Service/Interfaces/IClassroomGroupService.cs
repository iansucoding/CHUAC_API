using CHUACSystem.Data.Models;
using CHUACSystem.Service.ViewModels;
using System.Collections.Generic;

namespace CHUACSystem.Service.Interfaces
{
    public interface IClassroomGroupService: IGenericService<ClassroomGroup, ClassroomGroupView, ClassroomGroupBase>
    {
        IEnumerable<ClassroomGroupView> GetAllClassrooms();
    }
}
