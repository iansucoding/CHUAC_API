using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CHUACSystem.Api.Controllers
{
    [Route("api/other-setting")]
    public class OtherSettingController : Controller
    {
        private IOtherSettingService _otherSettingService;

        public OtherSettingController(IOtherSettingService otherSettingService)
        {
            _otherSettingService = otherSettingService;
        }
        // GET: api/other-setting/pump-delay-time
        [HttpGet("pump-delay-time")]
        public IActionResult GetPumpDelayTime()
        {
            return new ObjectResult(_otherSettingService.GetPumpDelayTime());
        }

        // PUT api/other-setting/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody]OtherSettingView model)
        {
            return new ObjectResult(_otherSettingService.Update(model));
        }

    }
}
