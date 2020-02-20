using Microsoft.AspNetCore.Mvc;
using SlavaQuest.Models;
using SlavaQuest.Models.enums;
using SlavaQuest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DutyController : ControllerBase
    {
        private readonly IDutyService _dutyService;
        public DutyController(IDutyService dutyService)
        {
            _dutyService = dutyService;
        }

        [HttpGet("get/one")]
        public ActionResult<IEnumerable<Duty>> GetDuty(Guid id)
        {
            return Ok(_dutyService.GetDuty(id));
        }

        //[HttpGet("get/bycondition")]
        //public ActionResult<IEnumerable<Duty>> GetDutyByCondition(bool onlyActive, int numOfApartament)
        //{
        //    return Ok(_dutyService.GetDutyByCondition(onlyActive, numOfApartament));
        //}

        [HttpGet("get/all")]
        public ActionResult<IEnumerable<Duty>> GetDuty()
        {
            return Ok(_dutyService.GetDuty());
        }

        [HttpPost("post")]
        public ActionResult CreateDuty([FromQuery]Duty duty)
        {
            _dutyService.AddDuty(duty);

            return Ok();
        }

        [HttpPut("put")]
        public ActionResult<Duty> UpdateDuty(Guid id, bool activeStatus, Level level)
        {
            Duty result = _dutyService.UpdateDuty(id, activeStatus, level);

            return Ok(result);
        }

        [HttpDelete("delete/one")]
        public ActionResult RemoveDuty(Guid id)
        {
            _dutyService.DeleteDuty(id);

            return Ok();
        }

    }
}
