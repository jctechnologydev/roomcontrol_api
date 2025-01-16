/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using Backend.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples;

/// <summary>
/// Classe para documentar os exemplos possiveis do atuador
/// </summary>
public class ActuatorStateExamples : IMultipleExamplesProvider<ActuatorState>
{
    /// <summary>
    /// Exemplos do Atuador
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SwaggerExample<ActuatorState>> GetExamples()
    {

        yield return SwaggerExample.Create(
            "Ligar",
            new ActuatorState()
            {
                Id = 1,
                State = "Ligar"
            });

        yield return SwaggerExample.Create(
            "Desligar",
            new ActuatorState()
            {
                Id = 2,
                State = "Desligar"
            });

        yield return SwaggerExample.Create(
           "Abrir",
           new ActuatorState()
           {
               Id = 5,
               State = "Abrir"
           });

        yield return SwaggerExample.Create(
           "Fechar",
           new ActuatorState()
           {
               Id = 6,
               State = "Fechar"
           });

        yield return SwaggerExample.Create(
            "Ligar Aquecimento",
            new ActuatorState()
            {
                Id = 7,
                State = "Ligar Aquecimento"
            });

        yield return SwaggerExample.Create(
            "Ligar Frio",
            new ActuatorState()
            {
                Id = 8,
                State = "Ligar Frio"
            });
    }
}