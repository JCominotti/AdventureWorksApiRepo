
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspGetBillOfMaterialsController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspGetBillOfMaterialsController(IProcedureRepository repository)
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

            var result = await _repository.ExecuteProcedureAsync("uspGetBillOfMaterials", parameters);
            return Ok(result);
        }
    }
}
