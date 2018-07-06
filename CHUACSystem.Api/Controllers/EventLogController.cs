using CHUACSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CHUACSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class EventLogController : Controller
    {
        private IEventLogService _eventLogService;

        public EventLogController(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_eventLogService.GetAll());
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _eventLogService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
