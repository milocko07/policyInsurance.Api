using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using policyInsurance.Data;
using policyInsurance.Data.Access;
using policyInsurance.Data.Repositories;
using policyInsurance.Entities.ViewModels;
using System.Net;
using System.Threading.Tasks;

namespace policyInsurance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : Controller
    {
        private IAccessPolicySelection accessPolicySelection;
        private IAccessPolicyCreation accessPolicyCreation;

        public PolicyController(AppIdentityDbContext context)
        {
            this.accessPolicySelection = new AccessPolicySelection(new UnitOfWork(context));
            this.accessPolicyCreation = new AccessPolicyCreation(new UnitOfWork(context));
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

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Save([FromBody] PolicySelectionViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            var result = accessPolicyCreation.Save(model);

            if (result == null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}