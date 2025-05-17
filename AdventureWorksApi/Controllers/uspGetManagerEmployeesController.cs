
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspGetManagerEmployeesController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspGetManagerEmployeesController(IProcedureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int BusinessEntityID)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@BusinessEntityID", BusinessEntityID }
            };

            var result = await _repository.ExecuteProcedureAsync("uspGetManagerEmployees", parameters);
            return Ok(result);
        }
    }
}
