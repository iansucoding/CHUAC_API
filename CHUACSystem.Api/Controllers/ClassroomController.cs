using CHUACSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/classroom")]
    public class ClassroomController : Controller
    {
        private IClassroomGroupService _classroomGroupService;

        public ClassroomController(IClassroomGroupService classroomGroupService)
        {
            _classroomGroupService = classroomGroupService;
        }
        // GET: api/classroom/all-classrooms
        [HttpGet("all-classrooms")]
        public IActionResult GetAllClassrooms()
        {
            return new OkObjectResult(_classroomGroupService.GetAllClassrooms());
        }

    }
}
