/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using Backend.Model.HardwareCRUD;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples;

/// <summary>
/// Classe para documentar no swagger os tipos de hardware a serem criados
/// </summary>
public class CreateHardwareExamples : IMultipleExamplesProvider<CreateHardware>
{
    /// <summary>
    /// Exemplos do Hardware
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SwaggerExample<CreateHardware>> GetExamples()
    {

        yield return SwaggerExample.Create(
            "Sensor",
            new CreateHardware()
            {
                IdRoom = 1,
                IdFuncionality = 1,
                IdHardwareType = 1,
                Name = "Sensor",
                MaxValue = 90,
                MinValue = 10,
            });
    yield return SwaggerExample.Create(
            "Actuador",
            new CreateHardware()
            {
                IdRoom = 1,
                IdFuncionality = 2,
                IdHardwareType = 1,
                Name = "Lâmpada",
            });
        
    }
}