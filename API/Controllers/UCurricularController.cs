using Backend.Examples;
using Backend.Model.Request;
using IPCA;
using IPCA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]"), Produces("application/json"), Authorize]
public class UCurricularController : ControllerBase
{
    /// <summary>
    /// Método para busca das unidades curriculares e as repetivas salas de aulas
    /// </summary>
    /// <response code="401">Unauthorized to see the classrooms and subjects</response>
    /// <response code="403">Something went wrong! Forbidden</response>
    /// <response code="200">Suceso da operação</response>
    /// <returns>Retorna uma lista de objetos UserClassroomSubject</returns>
    [HttpGet("rooms")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UCurricularListExamples))]
    public ActionResult<List<UCurricularDTO>> GetAllUserRooms()
    {
        int idUser;
        Int32.TryParse(User.FindFirst("UserID").Value, out idUser);
        if (idUser == null)
            return Unauthorized();

        List<UCurricularDTO> uCurricularList = new List<UCurricularDTO>();
        List<UserSubject> userSubjects = RepositoryFactory.GetUserSubjectRepository().GetUserSubjectByUser(idUser).Result;
        foreach (var userSubject in userSubjects)
        {
            UserSchedule userSchedule = RepositoryFactory.GetUserScheduleRepository().GetUserSchedulesByUserSubject(userSubject.IdUserSubject).Result;
            if (userSchedule != null)
            {
                Classroom classroom = RepositoryFactory.GetClassroomRepository().GetClassroom(userSchedule.IdClassRoom).Result;
                if (classroom != null)
                {
                    SubjectIPCA subjectIpca = RepositoryFactory.GetSubjectRepository().GetSubject(userSubject.IdSubject).Result;

                    if (subjectIpca != null)
                    {
                        UCurricularDTO uCurricular = new UCurricularDTO(subjectIpca, classroom);
                        uCurricularList.Add(uCurricular);   
                    }
                }
            }
        }
        
        return Ok(uCurricularList);
    }
}