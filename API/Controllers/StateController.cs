/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/

using Backend.Examples;
using Backend.Model;
using Backend.Model.Request;
using DAL.Model;
using DB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]"), Produces("application/json"), Authorize]
public class StateController : ControllerBase
{
    /// <summary>
    /// Método para busca de todos os estados do hardware
    /// </summary>
    /// <response code="200">Return all States</response>
    /// <returns>Retorna todos os estados existentes</returns>
    [HttpGet("All")]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StateListExamples))]
    public ActionResult<List<StateHardware>> GetAll()
    {
        return Ok(Application.Application.GetStateDao().GetAllState());
    }

    /// <summary>
    /// Método para Adicionar estado de um Hardware
    /// </summary>
    /// <response code="200">Return all States</response>
    /// <returns>Retorna todos os estados existentes</returns>
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [SwaggerRequestExample(typeof(StateDTO), typeof(StateChangerExamples))]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(StateChangedExamples))]
    [HttpPost("Add")]
    public ActionResult Add([FromBody] StateDTO state)
    {
        if(Application.Application.GetStateDao().Add(state))
            return Created("", state);
        return BadRequest();
    }

    /// <summary>
    /// Método para mudar o estado de um Hardware
    /// </summary>
    /// <param name="stateChanger"></param>
    /// <response code="200">State Changed</response>
    /// <returns>Retorna o novo estado do Hardware</returns>
    [HttpPatch("Change")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerRequestExample(typeof(StateChanger), typeof(StateChangerExamples))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StateChangedExamples))]
    public ActionResult<StateDTO> ChangeActuatorState([FromBody] StateChanger stateChanger)
    {
        StateDTO state = Application.Application.GetStateDao().GetState(stateChanger.IdState);
        Application.Application.Mqtt().SendMessage("set", stateChanger.IdHardware, state.Name);
        Application.Application.GetStateHistoric().SetState(stateChanger.IdHardware, stateChanger.IdState);
        return Ok();
    }
}