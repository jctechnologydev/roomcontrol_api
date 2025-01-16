using Backend.Model;
using DAL.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos estados possíveis de um tipo de dados
    /// </summary>
    public class DataTypeExamples : IMultipleExamplesProvider<DataTypeDTO>
    {
        /// <summary>
        /// Exemplos de tipos de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<DataTypeDTO>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Celsius",
                new DataTypeDTO()
                {
                    Id = 1,
                    Name = "Celsius"
                });

            yield return SwaggerExample.Create(
                "Kelvin",
                new DataTypeDTO()
                {
                    Id = 2,
                    Name = "Kelvin"
                });
            yield return SwaggerExample.Create(
               "Fahrenheit",
               new DataTypeDTO()
               {
                   Id = 2,
                   Name = "Kelvin"
               });
        }
    }
}
