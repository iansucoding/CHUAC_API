using CHUACSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class TemperatureHistoryController : Controller
    {
        private readonly ITemperatureHistoryService _temperatureHistoryService;

        public TemperatureHistoryController(ITemperatureHistoryService temperatureHistoryService)
        {
            _temperatureHistoryService = temperatureHistoryService;
        }
        // GET api/temperaturehistory/T1
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return new ObjectResult(_temperatureHistoryService.GetLatestTenByName(name));
        }    
    }
}
