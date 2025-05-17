
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspUpdateEmployeePersonalInfoController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspUpdateEmployeePersonalInfoController(IProcedureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int BusinessEntityID, string NationalIDNumber, DateTime BirthDate, string MaritalStatus, string Gender)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@BusinessEntityID", BusinessEntityID },
                { "@NationalIDNumber", NationalIDNumber },
                { "@BirthDate", BirthDate },
                { "@MaritalStatus", MaritalStatus },
                { "@Gender", Gender }
            };

            var result = await _repository.ExecuteProcedureAsync("uspUpdateEmployeePersonalInfo", parameters);
            return Ok(result);
        }
    }
}
