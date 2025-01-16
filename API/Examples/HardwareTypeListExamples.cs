using Backend.Model;
using DAL.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos da resposta dos estados possíveis de um tipo de hardware
    /// </summary>
    public class HardwareTypeListExamples : IMultipleExamplesProvider<List<HardwareTypeDTO>>
    {
        /// <summary>
        /// Exemplos de tipos de dados (Get)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<List<HardwareTypeDTO>>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "List1", new List<HardwareTypeDTO> {
                new HardwareTypeDTO()
                {
                    Id = 1,
                    Name = "Temperatura"
                },
                new HardwareTypeDTO()
                {
                    Id = 2,
                    Name = "Humidade"
                },
                new HardwareTypeDTO()
                {
                     Id = 3,
                     Name = "Luminosidade"
                }
                ,
                new HardwareTypeDTO()
                {
                     Id = 4,
                     Name = "Ruído"
                }
                ,
                new HardwareTypeDTO()
                {
                     Id = 5,
                     Name = "Movimento"
                },
                new HardwareTypeDTO()
                {
                     Id = 6,
                     Name = "CO2"
                }
            });
        }
    }
}
