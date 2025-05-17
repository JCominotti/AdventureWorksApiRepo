
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspPrintErrorController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspPrintErrorController(IProcedureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var parameters = new Dictionary<string, object>
            {
                
            };

            var result = await _repository.ExecuteProcedureAsync("uspPrintError", parameters);
            return Ok(result);
        }
    }
}
