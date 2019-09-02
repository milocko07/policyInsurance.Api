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
        private IAccessPolicyEdition accessPolicyEdition;
        private IAccessPolicyDeletion accessPolicyDeletion;

        public PolicyController(AppIdentityDbContext context)
        {
            this.accessPolicySelection = new AccessPolicySelection(new UnitOfWork(context));
            this.accessPolicyCreation = new AccessPolicyCreation(new UnitOfWork(context));
            this.accessPolicyEdition = new AccessPolicyEdition(new UnitOfWork(context));
            this.accessPolicyDeletion = new AccessPolicyDeletion(new UnitOfWork(context));
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
        public async Task<IActionResult> Create([FromBody] PolicySelectionViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid client request");
                }

                var result = accessPolicyCreation.Create(model);

                if (result == null)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        //[ValidateAntiForgeryToken]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Update([FromBody] PolicySelectionViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid client request");
                }

                var result = accessPolicyEdition.Update(model);

                if (result == null)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        //[ValidateAntiForgeryToken]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid client request");
                }


                var result = accessPolicyDeletion.Delete(id);

                if (result != null)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}