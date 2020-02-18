using Microsoft.AspNetCore.Mvc;
using SlavaQuest.Models;
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

        [HttpGet("get/all")]
        public ActionResult<IEnumerable<Duty>> GetDuty()
        {
            return Ok(_dutyService.GetAllDuty());
        }

        [HttpPost("post")]
        public ActionResult CreateDuty([FromQuery]Duty duty)
        {
            _dutyService.AddStudent(duty);

            return Ok();
        }

        [HttpPut("put")]
        public ActionResult<Duty> UpdateDuty(Guid id, bool activeStatus)
        {
            Student result = _dutyService.UpdateDuty(id, activeStatus);

            return Ok(result);
        }


    }
}
