using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHUACSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class TemporaryClassController : Controller
    {
        private ITemporaryClassService _temporaryClassService;

        public TemporaryClassController(ITemporaryClassService temporaryClassService)
        {
            _temporaryClassService = temporaryClassService;
        }
        // GET: api/temporaryclass
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_temporaryClassService.GetAll());
        }

        // POST api/temporaryclass
        [HttpPost]
        public IActionResult Post([FromBody]List<TemporaryClassBase> models)
        {
            try
            {
                var data = new List<TemporaryClassView>();
                models.ForEach(m => {
                    var result = _temporaryClassService.Create(m);
                    data.Add(_temporaryClassService.GetById(long.Parse(result.Message)));
                });

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/temporaryclass/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _temporaryClassService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
