using SlavaQuest.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Models
{
    public class Duty
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public bool IsActive { get; set; }
        public Level Level { get; set; }
    }
}
