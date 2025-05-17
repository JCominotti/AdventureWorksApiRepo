
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspLogErrorController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspLogErrorController(IProcedureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int ErrorLogID)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@ErrorLogID", ErrorLogID }
            };

            var result = await _repository.ExecuteProcedureAsync("uspLogError", parameters);
            return Ok(result);
        }
    }
}
