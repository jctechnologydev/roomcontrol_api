/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using Backend.Model.HardwareCRUD;
using DAL.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples;

/// <summary>   
/// Classe para documentar no swagger os Hardwares
/// </summary>
public class HardwareExamples : IMultipleExamplesProvider<HardwareResponse>
{

    /// <summary>
    /// Exemplo do Harware
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SwaggerExample<HardwareResponse>> GetExamples()
    {

        yield return SwaggerExample.Create(
            "Sensor",
            new HardwareResponse()
            {
                Id = 1,
                HardwareType = new HardwareTypeDTO{Id = 1, Name = "Temperatura"},
                FuncionalityType = new FuncionalityTypeDTO{Id = 1, Name = "Sensor"},
                Name = "Temperatura"
            });

        yield return SwaggerExample.Create(
            "Actuador",
            new HardwareResponse()
            {
                Id = 1,
                HardwareType = new HardwareTypeDTO{Id = 1, Name = "Luz"},
                FuncionalityType = new FuncionalityTypeDTO{Id = 1, Name = "Actuador"},
                Name = "Luz"
            });
    }
}

/*yield return SwaggerExample.Create(
            "Actuador",
            new HardwareModel()
            {
                IdHardware = 1,
                IdRoom = 1,
                IdHardwareType = 2,
                IdFuncionality = 2,
                Name = "Luz"
            });*/