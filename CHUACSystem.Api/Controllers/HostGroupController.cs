using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class HostGroupController : Controller
    {
        private readonly IHostGroupService _hostGroupService;

        public HostGroupController(IHostGroupService hostGroupService)
        {
            _hostGroupService = hostGroupService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_hostGroupService.GetAll());
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]HostGroupVM model)
        {
            return new ObjectResult(_hostGroupService.Update(model));
        }


    }
}
