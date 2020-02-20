using SlavaQuest.Db;
using SlavaQuest.Models;
using SlavaQuest.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SlavaQuest.Services.Implementations
{
    public class TenantsService : ITenantsService
    {
        private IDb _repository = null;
        public TenantsService(IDb tenantsRepository)
        {
            _repository = tenantsRepository;
        }
        public void AddTenant(Tenant tenants)
        {
            if (string.IsNullOrEmpty(tenants.Name))
            {
                throw new Exception("Tenants name is empty");
            }

            if (tenants.Name.Length > 15)
            {
                throw new Exception("Length of name bigger then 15 symbol's");
            }

            if (tenants.Age < 15 && tenants.Age > 65)
            {
                throw new Exception("Incorrect age");
            }

            tenants.Id = Guid.NewGuid();
            _repository.GetTenantsDb().Add(tenants);
        }

        public void DeleteAllTenants()
        {
            _repository.GetTenantsDb().Clear();
            _repository.GetDutyDb().Clear();
        }

        public void DeleteTenant(Guid id)
        {
            var tentn = ValidateTenantId(id);

            var duty = _repository.GetDutyDb().Find(s => s.TenantId == tentn.Id);

            if (duty != null)
            {
                _repository.GetDutyDb().Remove(duty);
            }

            _repository.GetTenantsDb().Remove(tentn);
        }

        public Tenant GetTenant(Guid id)
        {
            Tenant result = ValidateTenantId(id);

            return result;
        }
        public IEnumerable<Tenant> GetTenants()
        {
            return _repository.GetTenantsDb();
        }

        public Tenant UpdateTenant(Guid id, byte age, string name, short numApartment)
        {
            Tenant tenant = _repository.GetTenantsDb().Find(s => s.Id == id);

            if (tenant == null)
            {
                throw new Exception("Tenant is not found");
            }

            if (age != 0)
            {
                tenant.Age = age;
            }

            if (name != "")
            {
                tenant.Name = name;
            }

            if(numApartment != 0)
            {
                tenant.NumApartment = numApartment;
            }

            return tenant;
        }

        
        private Tenant ValidateTenantId(Guid id)
        {
            Tenant tenants = _repository.GetTenantsDb().Find(s => s.Id == id);

            if (tenants == null)
            {
                throw new Exception($"Tenatn with current id: {id} not found");
            }

            return tenants;
        }
    }
}