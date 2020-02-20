using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Models
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int NumApartment { get; set; }
        public Tenant()
        {

        }
        public Tenant(Guid Id, string name, int age, string gender, int numApartment)
        {
            this.Id = Id;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.NumApartment = numApartment;
        }
    }
}
