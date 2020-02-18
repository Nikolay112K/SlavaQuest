using Microsoft.AspNetCore.Mvc;
using SlavaQuest.Models;
using SlavaQuest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlavaQuest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantsService _tenantsService;
        public TenantsController(ITenantsService tenantsService)
        {
            _tenantsService = tenantsService;
        }

        [HttpGet("get/all")]
        public ActionResult<IEnumerable<Tenant>> GetTenants()
        {
            return Ok(_tenantsService.GetTenants());
        }

        [HttpGet("get/one")]
        public ActionResult<Tenant> GetTenants(Guid id)
        {
            return Ok(_tenantsService.GetTenant(id));
        }

        [HttpPost("post")]
        public ActionResult CreateTenants([FromQuery]Tenant tenant)
        {
            _tenantsService.AddTenant(tenant);

            return Ok();
        }

        [HttpPut("put")]
        public ActionResult<Tenant> UpdateTenant(Guid id, short numApartment, byte age = 0, string name = "")
        {
            if (age == 0 && name == "")
            {
                return BadRequest("Nothing to update");
            }

            Tenant result = _tenantsService.UpdateTenant(id, age, name, numApartment);

            return Ok(result);
        }

        [HttpDelete("delete/all")]
        public ActionResult RemoveAllTenants()
        {
            _tenantsService.DeleteAllTenants();

            return Ok();
        }

        [HttpDelete("delete/one")]
        public ActionResult RemoveTenant(Guid id)
        {
            _tenantsService.DeleteTenant(id);

            return Ok();
        }
    }
}
