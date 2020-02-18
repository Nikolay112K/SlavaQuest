﻿using SlavaQuest.Db;
using SlavaQuest.Models;
using SlavaQuest.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SlavaQuest.Services.Implementations
{
    public class TenantsService : ITenantsService
    {
        private IDb _tenantsRepository = null;
        public TenantsService(IDb tenantsRepository)
        {
            _tenantsRepository = tenantsRepository;
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
            _tenantsRepository.GetTenantDb().Add(tenants);
        }

        public void DeleteAllTenants()
        {
            _tenantsRepository = null;
        }

        public void DeleteTenant(Guid id)
        {
            _tenantsRepository.GetTenantDb().Remove(ValidateTenantId(id));
        }

        public Tenant GetTenant(Guid id)
        {
            Tenant result = ValidateTenantId(id);

            return result;
        }
        public IEnumerable<Tenant> GetTenants()
        {
            return _tenantsRepository.GetTenantDb();
        }

        public Tenant UpdateTenant(Guid id, byte age, string name, short numApartment)
        {
            Tenant tenants = _tenantsRepository.GetTenantDb().Find(s => s.Id == id);

            if (tenants == null)
            {
                throw new Exception("Tenant is not found");
            }

            if (age != 0)
            {
                tenants.Age = age;
            }

            if (name != "")
            {
                tenants.Name = name;
            }

            return tenants;
        }

        
        private Tenant ValidateTenantId(Guid id)
        {
            Tenant tenants = _tenantsRepository.GetTenantDb().Find(s => s.Id == id);

            if (tenants == null)
            {
                throw new Exception($"Tenatn with current id: {id} not found");
            }

            return tenants;
        }
    }
}