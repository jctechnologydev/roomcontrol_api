using Backend.Examples;
using IPCA;
using IPCA.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Controllers
{
    /// <summary>
    /// Contolador das escolas do IPCA
    /// </summary>
    /// 
    [ApiController]
    [Route("api/[controller]"), Produces("application/json")]
    public class SchoolController : ControllerBase
    {
        /// <summary>
        /// Função para busca de todas as escolas do IPCA
        /// </summary>
        /// <response code="404">Not Found</response>
        /// <response code="200">Ok</response>
        /// <returns>Retorna uma lista das escolas</returns>
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<School>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SchoolListExamples))]
        public ActionResult<Task<List<School>>> GetAllSchools()
        {
            List<School> buildings = RepositoryFactory.GetSchoolRepository().GetAllSchools().Result;
            if (buildings == null)
                return NotFound("Sem escolas");

            return Ok(buildings);
        }
    }
}
