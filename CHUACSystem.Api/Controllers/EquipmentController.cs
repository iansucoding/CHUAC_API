using CHUACSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/equipment")]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentGroupService _equipmentGroupService;

        public EquipmentController(IEquipmentGroupService equipmentGroupService)
        {
            _equipmentGroupService = equipmentGroupService;
        }

        // GET: api/equipment/all-equipments
        [HttpGet("all-equipments")]
        public IActionResult GetAllEquipments()
        {
            return new OkObjectResult(_equipmentGroupService.GetAllEquipments());
        }
    }
}
