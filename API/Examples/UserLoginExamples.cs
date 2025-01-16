/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using Backend.Model.Request;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples;
/// <summary>
/// Classe para documentar no swagger os tipos de utilizadores
/// </summary>
public class UserLoginExamples : IMultipleExamplesProvider<UserLogin>
{

    /// <summary>
    /// Exemplos dos dados de utilizadores
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SwaggerExample<UserLogin>> GetExamples()
    {
        
        yield return SwaggerExample.Create(
            "Admin",
            new UserLogin()
            {
                Email = "ruimanuel@alunos.ipca.pt",
                Password = "1235",
            });
        
        yield return SwaggerExample.Create(
            "Técnico",
            new UserLogin()
            {
                Email = "technician@ipca.pt",
                Password = "1234",
            });
        
        yield return SwaggerExample.Create(
            "Professor",
            new UserLogin()
            {
                Email = "lufer@ipca.pt",
                Password = "1234",
            });
        
        yield return SwaggerExample.Create(
            "Aluno",
            new UserLogin()
            {
                Email = "a19697@alunos.ipca.pt",
                Password = "1234",
            });
    }
}