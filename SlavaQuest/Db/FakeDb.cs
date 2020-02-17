using SlavaQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Db
{
    public class FakeDbService : IFakeDbService
    {
        private readonly List<Student> MyStudents = null;
        public FakeDbService()
        {
            MyStudents = new List<Student>
            {
                new Student { Id = new Guid("A5DAEDB1-0E26-4EBC-9C95-EE070F33BE93"), Age = 17, Name = "Frank" },
                new Student { Id = new Guid("A9E7FC33-7182-4F31-92C7-A8C835B4516A"), Age = 16, Name = "Thomas" }
            };
        }

        public List<Student> GetDataBase()
        {
            return MyStudents;
        }
    }
    public interface IFakeDbService
    {
        List<Student> GetDataBase();
    }
}
