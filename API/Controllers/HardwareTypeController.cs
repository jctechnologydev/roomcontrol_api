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
public class HardwareTypeController : ControllerBase
{
    /// <summary>
    /// Função para criar um tipo de hardware
    /// </summary>
    /// <param name="hardwareType">Dados para criar um tipo de Hardware</param>
    /// <response code="201">HardwareType created</response>
    /// <response code="400">HardwareType not found</response>
    /// <response code="500">Something went wrong! bad request</response>
    /// <returns>Retorna Ok e o objeto criado</returns>
    [HttpPost, Authorize(Roles = $"{nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(HardwareTypeDTO), StatusCodes.Status201Created)]
    [SwaggerRequestExample(typeof(HardwareTypeDTO), typeof(HardwareTypeExamples))]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(HardwareTypeExamples))]
    public ActionResult Add([FromBody] HardwareTypeDTO hardwareType)
    {
        try
        {
            if (hardwareType == null)
            {
                return BadRequest();
            }
            
            bool createHardwareType = Application.Application.GetHardwareTypeDao().Add(hardwareType);

            if ((createHardwareType) == false)
            {
                return StatusCode(500);
            }

            return Created("", hardwareType);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    /// <summary>
    /// Função para obter todos os tipos de hardware
    /// </summary>
    /// <response code="200">Lista obtida</response>
    /// <response code="500">Something went wrong! bad request</response>
    /// <returns></returns>
    [HttpGet, Authorize(Roles = $"{nameof(Roles.TECHNICIAN)}, {nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(List<HardwareTypeDTO>), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(HardwareTypeListExamples))]
    public ActionResult<List<HardwareTypeDTO>> GetAll()
    {
        List<HardwareTypeDTO> list = Application.Application.GetHardwareTypeDao().GetAllHardwareType();
        return Ok(list);
    }
    
    
}