using CHUACSystem.Data.Models;
using CHUACSystem.Service.ViewModels;
using System.Collections.Generic;

namespace CHUACSystem.Service.Interfaces
{
    public interface ITemperatureHistoryService: IGenericService<TemperatureHistory, TemperatureHistoryView, TemperatureHistoryBase>
    {
        IEnumerable<TemperatureHistoryView> GetLatestTenByName(string name);
    }
}
