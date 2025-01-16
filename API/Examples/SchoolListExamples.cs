using IPCA.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos edifiçios
    /// </summary>
    public class SchoolListExamples : IMultipleExamplesProvider<List<School>>
    {

        /// <summary>
        /// Exemplos dos edificios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<List<School>>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "List1", new List<School>
                {
                    new School()
                    {
                        IdSchool = 1,
                        Name = "Escola de Técnologia",
                        UrlToImage = "image.png"
                    },

                    new School()
                    {
                        IdSchool = 2,
                        Name = "Escola de Gestão",
                        UrlToImage = "image.png"
                    },
                    new School()
                    {
                        IdSchool = 3,
                        Name = "Escola de Design",
                        UrlToImage = "image.png"
                    },
                    new School()
                    {
                        IdSchool = 4,
                        Name = "Escola de Hotelaria e Turismo",
                        UrlToImage = "image.png"
                    }
                });
        }
    }
}
