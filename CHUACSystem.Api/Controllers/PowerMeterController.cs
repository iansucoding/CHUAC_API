using CHUACSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class PowerMeterController : Controller
    {
        private readonly IPowerMeterService _powerMeterService;

        public PowerMeterController(IPowerMeterService powerMeterService)
        {
            _powerMeterService = powerMeterService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_powerMeterService.GetAll());
        }
    }
}
