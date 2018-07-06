using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CHUACSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class SocketController : Controller
    {
        private readonly ACSystemSocketManager _socketManager;
        private readonly ITemperatureHistoryService _temperatureHistoryService;

        public SocketController(ACSystemSocketManager socketManager, ITemperatureHistoryService temperatureHistoryService)
        {
            _socketManager = socketManager;
            _temperatureHistoryService = temperatureHistoryService;
        }

        private async Task SaveData(string type, string name, string value)
        {
            if (type == "temperature")
            {
                var isTemp = double.TryParse(value, out double temp);
                if (isTemp)
                {
                    await Task.Run(() =>
                        _temperatureHistoryService.Create(
                            new TemperatureHistoryBase
                            {
                                Name = name,
                                Value = temp
                            }
                        )
                    );
                }

            }
        }

        private async Task SendMessage(string type, string name, string value)
        {
            var reading = new
            {
                type,
                name,
                value,
                createdAt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            };

            await _socketManager.SendMessageToAllAsync(JsonConvert.SerializeObject(reading));
        }

        [HttpGet("report")]
        public async Task Report(string type, string name, string value)
        {
            await SaveData(type, name, value);
            await SendMessage(type, name, value);
        }
    }
}
