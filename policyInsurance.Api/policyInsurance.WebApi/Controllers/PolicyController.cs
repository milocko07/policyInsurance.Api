using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using policyInsurance.Data.Access;
using policyInsurance.Data.Repositories;
using policyInsurance.Entities.ViewModels;
using policyInsurance.Services.Policy;
using System.Threading.Tasks;

namespace policyInsurance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : Controller
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            this._policyService = policyService;
        }

        [HttpGet()]
        [EnableCors("CorsPolicy")]

        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policies = await _policyService.Get();

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

                var result = _policyService.Create(model);

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

                var result = _policyService.Update(model);

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


                var result = _policyService.Delete(id);

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