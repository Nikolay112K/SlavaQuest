using SlavaQuest.Models;
using SlavaQuest.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Services.Interfaces
{
    public interface IDutyService
    {
        IEnumerable<Duty> GetDuty();
        Duty GetDuty(Guid id);
        void AddDuty(Duty duty);
        Duty UpdateDuty(Guid id, bool activeStatus, Level level);
        void DeleteDuty(Guid id);
    }
}
