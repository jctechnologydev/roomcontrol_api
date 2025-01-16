using Backend.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos estados possíveis de um atuador
    /// </summary>
    public class User404Examples : IMultipleExamplesProvider<String>
    {
        /// <summary>
        /// Exemplos de Estados de um Hardware
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<String>> GetExamples()
        {
            yield return SwaggerExample.Create(
            "Credenciais erradas",
            "Credenciais erradas");
            
        }
    }
}
