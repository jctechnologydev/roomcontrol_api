using Backend.Model;
using DAL.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos estados possíveis de um tipo de hardware
    /// </summary>
    public class HardwareTypeExamples : IMultipleExamplesProvider<HardwareTypeDTO>
    {
        /// <summary>
        /// Exemplos de tipos de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<HardwareTypeDTO>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Temperatura",
                new HardwareTypeDTO()
                {
                    Id = 1,
                    Name = "Temperatura"
                });

            yield return SwaggerExample.Create(
                "Humidade",
                new HardwareTypeDTO()
                {
                    Id = 2,
                    Name = "Humidade"
                });
            yield return SwaggerExample.Create(
                 "Humidade",
                 new HardwareTypeDTO()
                 {
                     Id = 3,
                     Name = "Luminosidade"
                 });
        }
    }
}
