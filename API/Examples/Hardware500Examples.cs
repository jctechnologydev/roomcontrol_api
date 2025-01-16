using Backend.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos estados possíveis de um atuador
    /// </summary>
    public class Hardware500Examples : IMultipleExamplesProvider<String>
    {
        /// <summary>
        /// Exemplos de Estados de um Hardware
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<String>> GetExamples()
        {
            yield return SwaggerExample.Create(
            "Something went wrong when deleting the records",
            "Something went wrong when deleting the record");
            
        }
    }
}
