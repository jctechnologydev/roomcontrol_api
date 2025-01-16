using Backend.Examples;
using Backend.Model;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Controllers;

/// <summary>
/// Controlador dos tipos de hardware
/// </summary>
[ApiController]
[Route("api/[controller]"), Produces("application/json")]
public class FuncionalityTypeController : ControllerBase
{
    /// <summary>
    /// Função para criar um tipo de funcionalidade
    /// </summary>
    /// <param name="funcionalityType">Dados para criar um tipo de funcionalidade</param>
    /// <response code="201">FuncionalityType created</response>
    /// <response code="400">FuncionalityType not found</response>
    /// <response code="500">Something went wrong! bad request</response>
    /// <returns>Retorna Ok e o objeto criado</returns>
    [HttpPost, Authorize(Roles = $"{nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(DataTypeDTO), StatusCodes.Status201Created)]
    [SwaggerRequestExample(typeof(FuncionalityTypeDTO), typeof(FuncionalityTypeExamples))]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(FuncionalityTypeExamples))]
    public ActionResult Add([FromBody] FuncionalityTypeDTO funcionalityType)
    {
        try
        {
            if (funcionalityType == null)
            {
                return BadRequest();
            }

            bool createFunctionalityType = Application.Application.GetFuncionalityTypeDao().Add(funcionalityType);

            if ((createFunctionalityType) == false)
            {
                return StatusCode(500);
            }

            return Created("", funcionalityType);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    /// <summary>
    /// Função para obter todos os tipos de funcionalidade
    /// </summary>
    /// <response code="200">Lista obtida</response>
    /// <response code="500">Something went wrong! bad request</response>
    /// <returns></returns>
    [HttpGet, Authorize(Roles = $"{nameof(Roles.TECHNICIAN)}, {nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(List<FuncionalityTypeDTO>), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(FuncionalityTypeListExamples))]
    public ActionResult<List<FuncionalityTypeDTO>> GetAll()
    {
        List<FuncionalityTypeDTO> list = Application.Application.GetFuncionalityTypeDao().GetAllFuncionality();
        return Ok(list);
    }
    
    
}