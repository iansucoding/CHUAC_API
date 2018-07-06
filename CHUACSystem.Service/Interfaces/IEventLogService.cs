using CHUACSystem.Data.Models;
using CHUACSystem.Service.ViewModels;

namespace CHUACSystem.Service.Interfaces
{
    public interface IEventLogService : IGenericService<EventLog, EventLogView, EventLogBase>
    {
    }
}
