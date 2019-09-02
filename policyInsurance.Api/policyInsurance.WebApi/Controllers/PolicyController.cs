﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using policyInsurance.Data;
using policyInsurance.Data.Access;
using policyInsurance.Data.Repositories;
using System.Threading.Tasks;

namespace policyInsurance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : Controller
    {
        private IAccessPolicySelection accessPolicySelection;

        public PolicyController(AppIdentityDbContext context)
        {
            this.accessPolicySelection = new AccessPolicySelection(new UnitOfWork(context));
        }

        [HttpGet()]
        [EnableCors("CorsPolicy")]

        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policies = await accessPolicySelection.Get();

            if (policies == null)
            {
                return NotFound();
            }

            return Ok(policies);
        }
    }
}