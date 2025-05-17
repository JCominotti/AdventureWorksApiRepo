
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspGetWhereUsedProductIDController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspGetWhereUsedProductIDController(IProcedureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int StartProductID, DateTime CheckDate)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@StartProductID", StartProductID },
                { "@CheckDate", CheckDate }
            };

            var result = await _repository.ExecuteProcedureAsync("uspGetWhereUsedProductID", parameters);
            return Ok(result);
        }
    }
}
