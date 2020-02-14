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
                new Student { Id = new Guid("A5DAEDB1-0E26-4EBC-9C95-EE070F33BE93"), Age = 17, Name = "Frank" },
                new Student { Id = new Guid("A9E7FC33-7182-4F31-92C7-A8C835B4516A"), Age = 16, Name = "Thomas" }
            };
        }

        [HttpGet("get/all")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(MyStudents);
        }

        [HttpGet("get/one")]
        public ActionResult<Student> GetStudent(Guid id)
        {
            var student = MyStudents.Find(s => s.Id == id);

            if (student == null)
            {
                return NotFound("I can't find, information is empty");
            }

            return Ok(student);
        }

        [HttpPost("post")]
        public ActionResult CreateStudent([FromQuery]Student student)
        {
            student.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(student.Name))
            {
                return BadRequest("Information is empty");
            }

            if (student != null)
            {
                return BadRequest("Invalid data");
            }

            if (student.Age < 15)
            {
                return BadRequest("He/she too young for been a student");
            }

            if (student.Age > 65)
            {
                return BadRequest("He/she too old for been a student");
            }

            MyStudents.Add(student);

            return Ok();
        }

        [HttpPut("put")]
        public ActionResult<Student> UpdateStudent(Guid id, byte age = 0, string name = "")
        {
            if (age == 0 && name == "")
            {
                return BadRequest("Nothing to update");
            }

            var student = MyStudents.Find(s => s.Id == id);

            if (age != 0)
            {
                student.Age = age;
            }

            if (name != "")
            {
                student.Name = name;
            }

            return Ok(student);
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
            var student = MyStudents.Find(s => s.Id == id);

            if (student == null)
            {
                return NotFound("What i need to delete? Information is empty");
            }
            MyStudents.Remove(student);

            return Ok();
        }
    }
}
