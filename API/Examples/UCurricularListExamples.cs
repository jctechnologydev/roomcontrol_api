using Backend.Model.Request;
using IPCA.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos dos edifiçios
    /// </summary>
    public class UCurricularListExamples : IMultipleExamplesProvider<List<UCurricularDTO>>
    {

        /// <summary>
        /// Exemplos dos edificios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<List<UCurricularDTO>>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "List1", new List<UCurricularDTO>
                {
                    new UCurricularDTO()
                    {
                        Id = 1,
                        Name = "Matemática Discreta",
                        Room = new Classroom{IdSchool = 1, IdClassroom = 1, Name = "Sala A", Lotation = 5, Position =  new Position{Latitude = 41.53774958234516, Longitude = -8.627396824803894} }
                    },

                    new UCurricularDTO()
                    {
                        Id = 1,
                        Name = "Integração de Sistemas de Informação",
                        Room = new Classroom{IdSchool = 1, IdClassroom = 1, Name = "Sala A", Lotation = 5, Position =  new Position{Latitude = 41.53774958234516, Longitude = -8.627396824803894} }

                    },
                    new UCurricularDTO()
                    {
                        Id = 1,
                        Name = "Matemática Discreta",
                        Room = new Classroom{IdSchool = 1, IdClassroom = 1, Name = "Sala A", Lotation = 5, Position =  new Position{Latitude = 41.53774958234516, Longitude = -8.627396824803894} }

                    }
                });
        }
    }
}
