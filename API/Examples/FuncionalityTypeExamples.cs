using Backend.Model;
using DAL.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos estados possíveis de um tipo de funcionalidade
    /// </summary>
    public class FuncionalityTypeExamples : IMultipleExamplesProvider<FuncionalityTypeDTO>
    {
        /// <summary>
        /// Exemplos de funcionalidades de um Hardware
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<FuncionalityTypeDTO>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Sensor",
                new FuncionalityTypeDTO()
                {
                    Id = 1,
                    Name = "Sensor"
                });

            yield return SwaggerExample.Create(
                "Atuador",
                new FuncionalityTypeDTO()
                {
                    Id = 2,
                    Name = "Atuador"
                });
        }
    }
}
