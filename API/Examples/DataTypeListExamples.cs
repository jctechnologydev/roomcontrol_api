using Backend.Model;
using DAL.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos de tipos de dados
    /// </summary>
    public class DataTypeListExamples : IMultipleExamplesProvider<List<DataTypeDTO>>
    {



        /// <summary>
        /// Exemplos reposta tipos de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<List<DataTypeDTO>>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "List 1", new List<DataTypeDTO>
                {
                    new DataTypeDTO()
                    {
                        Id = 1,
                        Name = "Celsius"
                    },
                     new DataTypeDTO()
                    {
                    Id = 2,
                    Name = "Kelvin"
                     },
                      new DataTypeDTO()
                    {
                       Id = 2,
                       Name = "Kelvin"
                     }
                });
        }
    }
}
