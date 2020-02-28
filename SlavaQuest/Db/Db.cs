using SlavaQuest.Models;
using SlavaQuest.Models.enums;
using System;
using System.Collections.Generic;

namespace SlavaQuest.Db
{
    public class Db : IDb
    {
        private static readonly List<Tenant> MyTenants = null;
        private static readonly List<Duty> DutyTenant = null;
        static Db()
        {
            Guid id0 = Guid.NewGuid();
            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            Guid id3 = Guid.NewGuid();
            MyTenants = new List<Tenant>
            {
                new Tenant {Id = id0, Age = 53, Name = "George", Gender = "Male", NumApartment = 1},
                new Tenant {Id = id1, Age = 24, Name = "Triss", Gender = "Female", NumApartment = 2},
                new Tenant {Id = id2, Age = 53, Name = "Alex", Gender = "Male", NumApartment = 3},
                new Tenant {Id = id3, Age = 31, Name = "Lucifer", Gender = "Male", NumApartment = 666}

            };

            DutyTenant = new List<Duty>
            {
                new Duty { Id = Guid.NewGuid(), TenantId = id0, IsActive = false, Level = Level.None },
                new Duty { Id = Guid.NewGuid(), TenantId = id1, IsActive = false, Level = Level.None },
                new Duty { Id = Guid.NewGuid(), TenantId = id2, IsActive = false, Level = Level.None },
                new Duty { Id = Guid.NewGuid(), TenantId = id3, IsActive = false, Level = Level.None }
            };
        }

        public List<Duty> GetDutyDb()
        {
            return DutyTenant;
        }

        public List<Tenant> GetTenantsDb()
        {
            return MyTenants;
        }
    }

    public interface IDb
    {
        List<Tenant> GetTenantsDb();
        List<Duty> GetDutyDb();
    }
}