using Backend.Model;
using DAL.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos estados possíveis de um tipo de funcionalidade
    /// </summary>
    public class FuncionalityTypeListExamples : IMultipleExamplesProvider<List<FuncionalityTypeDTO>>
    {
        /// <summary>
        /// Exemplos de funcionalidades de um Hardware
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<List<FuncionalityTypeDTO>>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "List 1", new List<FuncionalityTypeDTO> {
                new FuncionalityTypeDTO()
                {
                    Id = 1,
                    Name = "Sensor"
                },
                new FuncionalityTypeDTO()
                {
                    Id = 2,
                    Name = "Atuador"
                }
                });
        }
    }
}
