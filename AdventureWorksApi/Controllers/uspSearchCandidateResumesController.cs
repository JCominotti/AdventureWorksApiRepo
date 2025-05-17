
using Microsoft.AspNetCore.Mvc;
using AdventureWorksApi.Repositories;

namespace AdventureWorksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class uspSearchCandidateResumesController : ControllerBase
    {
        private readonly IProcedureRepository _repository;

        public uspSearchCandidateResumesController(IProcedureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string searchString, bool useInflectional, bool useThesaurus, int language)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@searchString", searchString },
                { "@useInflectional", useInflectional },
                { "@useThesaurus", useThesaurus },
                { "@language", language }
            };

            var result = await _repository.ExecuteProcedureAsync("uspSearchCandidateResumes", parameters);
            return Ok(result);
        }
    }
}
