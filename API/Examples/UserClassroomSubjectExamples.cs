using Backend.Model.Request;
using IPCA.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples;

public class UserClassroomExamples : IMultipleExamplesProvider<UserClassroomSubject>
{
    /// <summary>
    /// Exemplos de utilizadores do sistema
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SwaggerExample<UserClassroomSubject>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "Utilizador-Sala-Disciplina",
            new UserClassroomSubject()
            {
                Subject = new SubjectIPCA{IdSubject = 1, IdUser = 1, Subject = "Projeto Aplicado", Ects = 6},
                Classroom = new Classroom{IdClassroom = 1, IdSchool = 1, Name = "Sala N", Lotation = 50, Position = new Position{Latitude = 41.53774958234516, Longitude = -8.627396824803894}}
            });
    }
}