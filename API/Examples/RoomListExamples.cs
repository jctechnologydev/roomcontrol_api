using Backend.Model;
using DAL.Model;
using IPCA.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples
{
    /// <summary>
    /// Classe para documentar os exemplos de resposta das salas
    /// </summary>
    public class RoomListExamples : IMultipleExamplesProvider<List<Classroom>>
    {
        /// <summary>
        /// Exemplos de salas (Get)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SwaggerExample<List<Classroom>>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "List1", new List<Classroom> {
                new Classroom()
                {
                    IdClassroom = 1,
                    IdSchool = 2,
                    Position = new Position{Latitude = 41.53774958234516, Longitude = -8.627396824803894},
                    Name = "Sala N",
                    Lotation = 50,
                },
                new Classroom()
                {
                    IdClassroom = 4,
                    IdSchool = 1,
                    Position = new Position{Latitude = 71.53774958234516, Longitude = -8.627396824803894},
                    Name = "Sala 1",
                    Lotation = 50,
                },
                new Classroom()
                {
                    IdClassroom = 3,
                    IdSchool = 1,
                    Position = new Position{Latitude = 51.53774958234516, Longitude = -8.627396824803894},
                    Name = "Sala S",
                    Lotation = 50,
                }            
            });
        }
    }
}
