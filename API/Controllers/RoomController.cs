using Backend.Examples;
using Backend.Model.Request;
using IPCA;
using IPCA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]"), Produces("application/json"), Authorize]
public class RoomController : ControllerBase
{
    /// <summary>
    /// Método para busca das unidades curriculares e as repetivas salas de aulas
    /// </summary>
    /// <response code="401">Unauthorized to see the classrooms and subjects</response>
    /// <response code="403">Something went wrong! Forbidden</response>
    /// /// <response code="200">Suceso da operação</response>
    /// <returns>Retorna uma lista de objetos UserClassroomSubject</returns>
    [HttpGet("All")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(List<Classroom>), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RoomListExamples))]
    public ActionResult<List<Classroom>> GetAll()
    {
        List<Classroom> classrooms = RepositoryFactory.GetClassroomRepository().GetAllClassrooms().Result;
        return Ok(classrooms);
    }
    
    
    [HttpGet("School/{idSchool}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(List<Classroom>), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RoomListExamples))]
    public ActionResult<List<Classroom>> GetAllFromSchool([FromRoute] int idSchool)
    {
        List<Classroom> classrooms = RepositoryFactory.GetClassroomRepository().GetClassroomFromSchool(idSchool).Result;
        return Ok(classrooms);
    }

}