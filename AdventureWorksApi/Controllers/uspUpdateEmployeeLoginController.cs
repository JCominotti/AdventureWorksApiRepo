
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspUpdateEmployeeLoginController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspUpdateEmployeeLoginController(IProcedureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int BusinessEntityID, string OrganizationNode, string LoginID, string JobTitle, DateTime HireDate, string CurrentFlag)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@BusinessEntityID", BusinessEntityID },
                { "@OrganizationNode", OrganizationNode },
                { "@LoginID", LoginID },
                { "@JobTitle", JobTitle },
                { "@HireDate", HireDate },
                { "@CurrentFlag", CurrentFlag }
            };

            var result = await _repository.ExecuteProcedureAsync("uspUpdateEmployeeLogin", parameters);
            return Ok(result);
        }
    }
}
