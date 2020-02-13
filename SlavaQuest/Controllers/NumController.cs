using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SlavaQuest.Models;

namespace SlavaQuest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumController : ControllerBase
    {
        Student MyStudent = null;

        public NumController()
        {
            //MyStudent = new Student(Guid.NewGuid(),1,"nick");
        }

        [HttpGet("G")]
        public ActionResult<string> GetString()
        {
            return Ok(MyStudent);
        }

        [HttpPost("PO")]
        public ActionResult CreateString([FromQuery]Student student)
        {
            if (student != null)
            {
                return BadRequest("invalid data");
            }

            MyStudent = student;
            MyStudent.Id = Guid.NewGuid();

            return Ok();
        }
        
        [HttpPut("PU")]
        public ActionResult<string> UpdateString(byte age = 0, string name = "")
        {
            if (age != 0)
            {
                MyStudent.Age = age;
            }

            if (name != "")
            {
                MyStudent.Name = name;
            }

            if (age == 0 && name == "")
            {
                return BadRequest("nothing to update");
            }

            return Ok(MyStudent);
        }

        [HttpDelete("D")]
        public ActionResult RemoveString()
        {
            MyStudent = null;

            return Ok();
        }
    }
}
