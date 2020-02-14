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
        List<Student> MyStudents = null;

        public NumController()
        {

            MyStudents = new List<Student>
            {
                new Student { Id = Guid.NewGuid(), Age = 17, Name = "Frank" },
                new Student { Id = Guid.NewGuid(), Age = 16, Name = "Thomas" }
            };
        }

        [HttpGet("GET")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(MyStudents);
        }

        [HttpPost("POST")]
        public ActionResult CreateStudent([FromQuery]Student student)
        {
            if (student != null)
            {
                return BadRequest("invalid data");
            }

            student.Id = Guid.NewGuid();
            MyStudents.Add(student);

            return Ok();
        }
        
        [HttpPut("PUT")]
        public ActionResult<string> UpdateStudent(byte age = 0, string name = "")
        {
            //if (age != 0)
            //{
            //    MyStudents.Age = age;
            //}

            //if (name != "")
            //{
            //    MyStudents.Name = name;
            //}

            if (age == 0 && name == "")
            {
                return BadRequest("nothing to update");
            }

            return Ok(MyStudents);
        }

        [HttpDelete("delete/all")]
        public ActionResult RemoveAllStudens()
        {
            MyStudents = null;

            return Ok();
        }

        [HttpDelete("delete/one")]
        public ActionResult RemoveStudent(Guid id)
        {
            var student = MyStudents.Find(s=>s.Id == id);
            MyStudents.Remove(student);

            return Ok();
        }
    }
}
