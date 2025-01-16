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
/// 
/// </summary>
public class UpdateHardwareExamples : IMultipleExamplesProvider<UpdateHardware>
{
    public IEnumerable<SwaggerExample<UpdateHardware>> GetExamples()
    {
        
        yield return SwaggerExample.Create(
            "Sensor",
            new UpdateHardware()
            {
                Id = 25,
                Name = "Sensor",
                MaxValue = 90,
                MinValue = 10,
            });
        
        yield return SwaggerExample.Create(
            "Actuador",
            new UpdateHardware()
            {   
                Id = 26,
                Name = "Janela",
            });
        
    }
}