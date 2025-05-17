
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspUpdateEmployeeHireInfoController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspUpdateEmployeeHireInfoController(IProcedureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int BusinessEntityID, string JobTitle, DateTime HireDate, DateTime RateChangeDate, string Rate, byte PayFrequency, string CurrentFlag)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@BusinessEntityID", BusinessEntityID },
                { "@JobTitle", JobTitle },
                { "@HireDate", HireDate },
                { "@RateChangeDate", RateChangeDate },
                { "@Rate", Rate },
                { "@PayFrequency", PayFrequency },
                { "@CurrentFlag", CurrentFlag }
            };

            var result = await _repository.ExecuteProcedureAsync("uspUpdateEmployeeHireInfo", parameters);
            return Ok(result);
        }
    }
}
