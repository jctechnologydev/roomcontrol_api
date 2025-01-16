/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using System.ComponentModel.DataAnnotations;
using Backend.Examples;
using Backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]"), Produces("application/json")]
public class ActuatorsController
{
    /// <summary>
    /// Função para enviar estado do atuador
    /// Permite ligar ou desligar equipamentos
    /// </summary>
    /// <param name="actuatorState">Estado do atuador</param>
    /// <returns>Retorna o sucesso da operação</returns>
    [HttpPost("state"), Authorize(Roles = $"{nameof(Roles.TEACHER)}, {nameof(Roles.TECHNICIAN)},{nameof(Roles.ADMIN)}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [SwaggerRequestExample(typeof(ActuatorState), typeof(ActuatorStateExamples))]
    //[SwaggerResponseExample(StatusCodes.Status200OK, typeof(ActuatorState))]
    public IActionResult SetState([FromBody][Required] ActuatorState actuatorState)
    {
        Application.Application.Mqtt().SendMessage("set", actuatorState.Id, actuatorState.State);
        return new OkResult();
    }
}