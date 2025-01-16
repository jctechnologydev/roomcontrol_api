/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/

using Backend.Model.Request;
using IPCA.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Backend.Examples;

/// <summary>
/// Classe para documentar no swagger os tipos de utilizadores
/// </summary>
public class UserExamples : IMultipleExamplesProvider<LoginDTO>
{
    /// <summary>
    /// Exemplos de utilizadores do sistema
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SwaggerExample<LoginDTO>> GetExamples()
    {
        yield return SwaggerExample.Create(
            "Técnico",
            new LoginDTO()
            {
                Name = "technician",
                Course = "Engenharia de Sistemas Informáticos",
                UserType = "Técnico",
                Token = "TokenForThisUser"
            });

        yield return SwaggerExample.Create(
            "Admin",
            new LoginDTO()
            {
                Name = "Rui Manuel",
                Course = "Engenharia de Sistemas Informáticos",
                UserType = "Admin",
                Token = "TokenForThisUser"
            });
        
        yield return SwaggerExample.Create(
            "Professor",
            new LoginDTO()
            {
                Name = "Luís Ferreira",
                Course = "Engenharia de Sistemas Informáticos",
                UserType = "Professor",
                Token = "TokenForThisUser"
            });
        
        yield return SwaggerExample.Create(
            "Aluno",
            new LoginDTO()
            {
                Name = "José Macedo",
                Course = "Engenharia de Sistemas Informáticos",
                UserType = "Aluno",
                Token = "TokenForThisUser"
            });
    }
}