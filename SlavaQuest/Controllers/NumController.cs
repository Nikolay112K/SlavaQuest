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
            return Ok(ValidateStudentId(id));
        }

        [HttpPost("post")]
        public ActionResult CreateStudent([FromQuery]Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                return BadRequest("Student name is empty");
            }

            if (student.Name.Length > 15)
            {
                throw new Exception("Length of name bigger then 15 symbol's");
            }

            if (student.Age < 15 && student.Age > 65)
            {
                return BadRequest("Incorrect age");
            }

            student.Id = Guid.NewGuid();
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

            if(student == null)
            {
                NotFound("Student is not found");
            }

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
            MyStudents.Remove(ValidateStudentId(id));

            return Ok();
        }

        private Student ValidateStudentId(Guid id)
        {
            var student = MyStudents.Find(s => s.Id == id);

            if (student == null)
            {
                throw new Exception($"Student with current id: {id} not found");
            }

            return student;
        }
    }
}
