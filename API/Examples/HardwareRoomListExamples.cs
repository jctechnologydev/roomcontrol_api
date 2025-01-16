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
/// Classe para documentar no swagger 0 get de 
/// </summary>
public class HardwarRoomListeExamples : IMultipleExamplesProvider<List<RoomDataDTO>>
{

    /// <summary>
    /// Exemplo do Harware
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SwaggerExample<List<RoomDataDTO>>> GetExamples()
    {

        yield return SwaggerExample.Create(
            "List1", new List<RoomDataDTO> {
            new RoomDataDTO()
            {
                IdRoom = 1,
                DataTypeName =  "Celcius",
                Hardware = new HardwareDTO{Id = 1, FuncionalityType = new FuncionalityTypeDTO{Id = 1, Name = "Sensor"}, HardwareType= new HardwareTypeDTO{Id = 1, Name = "Temperatura"}, Name = "Sensor1"},
                State = "",
                Value = "22"
            },

            new RoomDataDTO()
            {
                IdRoom = 2,
                DataTypeName =  "",
                Hardware = new HardwareDTO{Id = 2, FuncionalityType = new FuncionalityTypeDTO{Id = 2, Name = "Atuador"}, HardwareType= new HardwareTypeDTO{Id = 2, Name = "Lumen"}, Name = "Atuador1"},
                State = "Ligado",
                Value = ""
            }
            });
    }
}
