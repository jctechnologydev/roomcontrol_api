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
public class DataTypeController : ControllerBase
{
    /// <summary>
    /// Função para criar um tipo de dados
    /// </summary>
    /// <param name="dataType">Dados para criar um tipo de dados</param>
    /// <response code="201">DataType created</response>
    /// <response code="400">DataType not found</response>
    /// <response code="500">Something went wrong! bad request</response>
    /// <returns>Retorna Ok e o objeto criado</returns>
    [HttpPost, Authorize(Roles = $"{nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(DataTypeDTO), StatusCodes.Status201Created)]
    [SwaggerRequestExample(typeof(DataTypeDTO), typeof(DataTypeExamples))]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(DataTypeExamples))]
    public ActionResult Add([FromBody] DataTypeDTO dataType)
    {
        try
        {
            if (dataType == null)
            {
                return BadRequest();
            }
            
            bool createDataType = Application.Application.GetDataTypeDao().CreateDataType(dataType);

            if ((createDataType) == false)
            {
                return StatusCode(500);
            }

            return Created("", dataType);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    /// <summary>
    /// Função para obter todos os tipos de dados
    /// </summary>
    /// <response code="200">Lista obtida</response>
    /// <response code="500">Something went wrong! bad request</response>
    /// <returns></returns>
    [HttpGet, Authorize(Roles = $"{nameof(Roles.TECHNICIAN)}, {nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(List<DataTypeDTO>), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(DataTypeListExamples))]
    public ActionResult<List<DataTypeDTO>> GetAll()
    {
        List<DataTypeDTO> list = Application.Application.GetDataTypeDao().GetAllDataType();
        return Ok(list);
    }
    
    
}