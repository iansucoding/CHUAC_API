using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/equip-conn")]
    public class EquipConnController : Controller
    {
        private IEquipConnService _equipConnService;

        public EquipConnController(IEquipConnService equipConnService)
        {
            _equipConnService = equipConnService;
        }
        // GET: api/equip-conn
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_equipConnService.GetAll());
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]List<EquipConnView> models)
        {
            var result = new ReturnVM();
            try
            {
                models.ForEach(x =>
                {
                    var currentUpdate = _equipConnService.Update(x);
                    if (!currentUpdate.IsSuccess)
                    {
                        result.Message += currentUpdate.Message + "; ";
                    }
                });
                if (!string.IsNullOrEmpty(result.Message))
                {
                    result.Message = "部分更新失敗: " + result.Message;
                }
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return new ObjectResult(result);
        }

    }
}
