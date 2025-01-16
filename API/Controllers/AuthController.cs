/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Examples;
using Backend.Model;
using Backend.Model.Request;
using IPCA;
using IPCA.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]"), Produces("application/json")]
public class AuthController : ControllerBase
{

    private IConfiguration _config;

    /// <summary>
    /// Construtor da classe para a injeção de dependências
    /// </summary>
    /// <param name="configuration"></param>
    public AuthController(IConfiguration configuration)
    {
        _config = configuration;
    }
    /// <summary>
    /// Função para iniciar sessão no sistema
    /// </summary>
    /// <param name="userLogin">Credenciais do utilizador</param>
    /// <response code="200">Login Sucess</response>
    /// <response code="501">BadRequest</response>
    /// <returns>Retorna informações do utilizador</returns>
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(LoginDTO), StatusCodes.Status200OK)]
    [SwaggerRequestExample(typeof(UserLogin), typeof(UserLoginExamples))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserExamples))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(User404Examples))]
    public ActionResult<LoginDTO> Login([FromBody] UserLogin userLogin)
    {
        User user = RepositoryFactory.GetUserRepository().Login(userLogin.Email, userLogin.Password).Result;
        if (user == null)
            return NotFound("Credenciais erradas!");

        Course course = null;
        List<UserSubject> userSubjects = RepositoryFactory.GetUserSubjectRepository().GetUserSubjectByUser(user.IdUser).Result;
        if (userSubjects != null && userSubjects.Count > 0)
        {
            UserSchedule userSchedule = RepositoryFactory.GetUserScheduleRepository()
                .GetUserSchedulesByUserSubject(userSubjects[0].IdUserSubject).Result;
            if (userSchedule != null)
            {
                course = RepositoryFactory.GetCourseRepository().GetCoursesById(userSchedule.IdCourse).Result;
            }
        }

        
        string userType = user.IdTypeUser.ToString();

        LoginDTO login = new LoginDTO()
        {
            Name = user.Name,
            UserType = userType,
            Token = GerarTokenJWT(user.IdUser, user.IdTypeUser),
            ImageUrl = user.UrlToImage
        };

        if (course != null)
            login.Course = course.Name;

        return login;
    }
    
    private string GerarTokenJWT(int idUser, int role) {
        var issuer = _config["Jwt:Issuer"];
        var audience = _config["Jwt:Audience"];
        var expiry = DateTime.Now.AddHours(1);
        var securityKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); 
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: expiry,
            claims: new Claim[]
            {
                new(ClaimTypes.Role, ((Roles)role).ToString()),
                new("UserID", idUser.ToString())
            },
            signingCredentials: credentials);
        var tokenHandler = new JwtSecurityTokenHandler(); 
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}