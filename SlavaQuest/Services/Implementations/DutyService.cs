using SlavaQuest.Db;
using SlavaQuest.Models;
using SlavaQuest.Models.enums;
using SlavaQuest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Services.Implementations
{
    public class DutyService : IDutyService
    {
        private IDb _DbRepository = null;
        public DutyService(IDb dutyRepository)
        {
            _DbRepository = dutyRepository;
        }
        public void AddDuty(Duty duty)
        {
            var tenant =_DbRepository.GetTenantsDb().Find(t => t.Id == duty.TenantId);

            if (tenant == null)
            {
                throw new Exception($"Tenant with id {duty.Id}");
            }

            duty.Id = Guid.NewGuid();
            _DbRepository.GetDutyDb().Add(duty);
        }

        public void DeleteDuty(Guid id)
        {
            Duty duty = ValidateDutyId(id);

            Tenant currentTenant = _DbRepository.GetTenantsDb().Find(n => n.Id == duty.TenantId);

            IEnumerable<Tenant> allTenants = _DbRepository.GetTenantsDb().Where(t => t.NumApartment == currentTenant.NumApartment);

            if(allTenants.Count() > 1)
            {
                _DbRepository.GetDutyDb().Remove(duty);
            }
            else
            {
                throw new Exception($"Tenant can't be removed, need more then 1 tenant in apart");
            }
        }

        public Duty GetDuty(Guid id)
        {
            var result = ValidateDutyId(id);

            return result;
        }
        public IEnumerable<Duty> GetDuty()
        {
            return _DbRepository.GetDutyDb();
        }

        public Duty UpdateDuty(Guid id, bool isActive, Level level)
        {
            var duty = ValidateDutyId(id);

            duty.Level = level;
            duty.IsActive = isActive;

            return duty;
        }


        private Duty ValidateDutyId(Guid id)
        {
            Duty duty = _DbRepository.GetDutyDb().Find(s => s.Id == id);

            if (duty == null)
            {
                throw new Exception($"Duty with current id: {id} not found");
            }

            return duty;
        }
    }
}
