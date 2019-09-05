using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using policyInsurance.Entities.ViewModels;
using policyInsurance.Services.Policy;
using System.Threading.Tasks;

namespace policyInsurance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyAssigmentController : ControllerBase
    {
        private readonly IPolicyAssigmentService _policyAssigmentService;

        public PolicyAssigmentController(IPolicyAssigmentService policyAssigmentService)
        {
            this._policyAssigmentService = policyAssigmentService;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route("assign")]
        public async Task<IActionResult> Assign([FromBody] PolicyAssignationViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            return Ok(await _policyAssigmentService.Assign(model));
        }

        [HttpDelete]
        [EnableCors("CorsPolicy")]
        [Route("cancel")]
        public async Task<IActionResult> Cancel([FromBody] PolicyAssignationViewModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid client request");
            }

            return Ok(await _policyAssigmentService.Cancel(model));
        }
    }
}