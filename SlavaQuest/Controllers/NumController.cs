using Microsoft.AspNetCore.Mvc;
using SlavaQuest.Models;
using SlavaQuest.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SlavaQuest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumController : ControllerBase
    {
        private readonly IStudenService _studentService;
        public NumController(IStudenService studenService)
        {
            _studentService = studenService;
        }

        [HttpGet("get/all")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(_studentService.GetStudents());
        }

        [HttpGet("get/one")]
        public ActionResult<Student> GetStudent(Guid id)
        {
            return Ok(_studentService.GetStudent(id));
        }

        [HttpPost("post")]
        public ActionResult CreateStudent([FromQuery]Student student)
        {
            _studentService.AddStudent(student);

            return Ok();
        }

        [HttpPut("put")]
        public ActionResult<Student> UpdateStudent(Guid id, byte age = 0, string name = "")
        {
            if (age == 0 && name == "")
            {
                return BadRequest("Nothing to update");
            }

            Student result = _studentService.UpdateStudent(id, age, name);

            return Ok(result);
        }

        [HttpDelete("delete/all")]
        public ActionResult RemoveAllStudens()
        {
            _studentService.DeleteAllStudents();

            return Ok();
        }

        [HttpDelete("delete/one")]
        public ActionResult RemoveStudent(Guid id)
        {
            _studentService.DeleteStudent(id);

            return Ok();
        }
    }
}
