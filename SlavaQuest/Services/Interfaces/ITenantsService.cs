using SlavaQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Services.Interfaces
{
    public interface ITenantsService
    {
        IEnumerable<Tenant> GetTenants();
        Tenant GetTenant(Guid id);
        void AddTenant(Tenant tenant);
        Tenant UpdateTenant(Guid id, byte age, string name, short numApartment);
        void DeleteTenant(Guid id);
        void DeleteAllTenants();

    }
}
