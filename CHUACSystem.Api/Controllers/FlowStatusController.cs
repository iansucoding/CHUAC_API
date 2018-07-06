using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/flow-status")]
    public class FlowStatusController : Controller
    {
        private IFlowStatusService _flowStatusServicese;

        public FlowStatusController(IFlowStatusService flowStatusServicese)
        {
            _flowStatusServicese = flowStatusServicese;
        }
        // GET: api/flow-status
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_flowStatusServicese.GetAll());
        }

        // PUT api/flowstatus
        [HttpPut]
        public IActionResult Put([FromBody]List<FlowStatusVM> models)
        {
            var result = new ReturnVM();
            try
            {
                models.ForEach(x =>
                {
                    var currentUpdate = _flowStatusServicese.Update(x);
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
