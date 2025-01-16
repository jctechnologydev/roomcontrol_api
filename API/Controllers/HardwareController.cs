/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using DAL.Model;
using Backend.Model.HardwareCRUD;
using AutoMapper;
using Backend.Examples;
using TemperatureConverter;
using Backend.Model;
using DB.Model;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers;

/// <summary>
/// Controlador dos Sensores
/// </summary>
[ApiController]
[Route("api/[controller]"), Produces("application/json")]
public class HardwareController : ControllerBase
{

    private readonly IMapper _mapper;

    /// <summary>
    /// Construtor para injeção de dependências do AutoMapper
    /// </summary>
    /// <param name="mapper">interface do AutoMapper</param>
    public HardwareController(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Função para procurar um hardware por id e retorna-o
    /// </summary>
    /// <param name="idHardware">id a ser pesquisado</param>
    /// <response code="200">Hardware finded</response>
    /// <response code="400">Hardware not found</response>
    /// <response code="500">Something went wrong! bad request</response>
    /// <returns>Retorna o sucesso da operação e os dados do hardware encontrado</returns>
    [HttpGet, Authorize]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(HardwareDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(HardwareExamples))]
    public ActionResult<HardwareDTO> GetHardware(int idHardware)
    {
        try
        {
            HardwareDTO hardware = Application.Application.GetHardwareDao().GetHardware(idHardware);
            
            if (hardware == null)
            {
                return NotFound("Hardware not found");
            }
            return Ok(hardware);

        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Função para criar um hardware
    /// </summary>
    /// <param name="hardware">Dados para criar um Hardware</param>
    /// <response code="201">Hardware created</response>
    /// <response code="400">Hardware not found</response>
    /// <response code="500">Something went wrong! bad request</response>
    /// <returns>Retorna Ok e o objeto criado</returns>
    [HttpPost, Authorize(Roles = $"{nameof(Roles.TECHNICIAN)}, {nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(HardwareDTO), StatusCodes.Status201Created)]
    [SwaggerRequestExample(typeof(CreateHardware), typeof(CreateHardwareExamples))]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(HardwareExamples))]
    public ActionResult<HardwareDTO> CreateHardware([FromBody] CreateHardware hardware)
    {
        try
        {
            if (hardware == null)
            {
                return BadRequest();
            }
            var hardwareObj = _mapper.Map<HardwareDTO>(hardware);                 

            AlertDTO alertObj = new AlertDTO
            {
                MaxValue = hardware.MaxValue,
                MinValue = hardware.MinValue,
            };
            int idUser = 1;

            bool createHardware = Application.Application.GetHardwareDao().CreateHardware(hardwareObj, alertObj, hardware.IdRoom, idUser);

            if ((createHardware) == false)
            {
                return StatusCode(500);
            }

            return Created("", hardware);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


   //// <summary>
    /// Função para atualizar o Hardware
    /// </summary>
    /// <param name="hardware">Dados para atualização</param>
    /// <response code="201">Hardware updated</response>
    /// <response code="501">Something went wrong!Internal Server Error</response>
    /// <returns>Retorna os dados do objeto atulizado</returns>
    [HttpPut, Authorize(Roles= $"{nameof(Roles.TECHNICIAN)}, {nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(HardwareDTO), StatusCodes.Status201Created)]
    [SwaggerRequestExample(typeof(UpdateHardware), typeof(UpdateHardwareExamples))]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(HardwareExamples))]
    [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(Hardware500Examples))]
    public ActionResult<HardwareDTO> UpdateHardware([FromBody] UpdateHardware hardware)
    {
        try
        {
            if (hardware == null)
            {
                return BadRequest(ModelState); //Model State contém todos erros que são encontrados
            }
            var hardwareObj = _mapper.Map<HardwareDTO>(hardware);
            AlertDTO alertObj = new AlertDTO
            {
                Id = hardware.Id,
                MaxValue = hardware.MaxValue,
                MinValue = hardware.MinValue,
            };
            
            bool sensor = Application.Application.GetHardwareDao().UpdateHardware(hardwareObj, alertObj);

            if (!(sensor))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {hardwareObj.Name}");
                return StatusCode(500, ModelState);
            }
            return Created("",hardware);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    /// <summary>
    /// Função para apagar um Hardware e suas dependencias
    /// </summary>
    /// <param name="idHardware">id to Hardware a ser eliminado</param>
    /// <response code="204">Hardaware Deleted - No content</response>
    /// <response code="500">Internal server error/response>
    /// <response code="404">Hardaware Not Found</response>
    /// <returns>Retorna o sucesso da operação</returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HardwareDTO), StatusCodes.Status204NoContent)]
    [SwaggerResponseExample(StatusCodes.Status500InternalServerError, typeof(Hardware500Examples))]
    public ActionResult<HardwareDTO> DeleteHardware(int idHardware)
    {
        try
        {
            if (!Application.Application.GetHardwareDao().DeleteHardware(idHardware))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record");
                return StatusCode(500);
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("Room/{idRoom}"), Authorize]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(HardwarRoomListeExamples))]
    public ActionResult<List<RoomDataDTO>> GetAllRoomHardware([FromRoute] int idRoom)
    {
        List<RoomDataDTO> roomHardware = Application.Application.GetHardwareDao().GetHardwareRoom(idRoom);
        return roomHardware;
    }
}