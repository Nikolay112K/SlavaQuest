using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public byte Age { get; set; }
        public string Name { get; set; }
        public Student()
        {

        }
        public Student(Guid Id, Byte age, String name)
        {
            this.Id = Id;
            this.Age = age;
            this.Name = name;
        }
    }
}
