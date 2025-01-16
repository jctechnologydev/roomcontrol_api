/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/

using System.Net;
using System.Web;
using IPCA.Model;
using Newtonsoft.Json;

namespace IPCA;

public class UsersSubjectRepository : IUserSubjectRepository
{
    private readonly string url = "usersSubjects";

    /// <summary>
    /// Método que faz a busca de todas associações do utilizador e disciplina
    /// </summary>
    /// <returns>Retorna uma lista de utilizadores e disciplinas</returns>
    public async Task<List<UserSubject>> GetAllUserSubject()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<UserSubject> userSubjects = JsonConvert.DeserializeObject<List<UserSubject>>(resp);
        return userSubjects;
    }

    /// <summary>
    /// Método que faz a busca de todas associações do utilizador e disciplina por id do utilizador
    /// </summary>
    /// <param name="idUser">id do utilizador</param>
    /// <returns>Retorna uma lista de todas associações disciplina-utilizador de um determinado utilizador</returns>
    public async Task<List<UserSubject>> GetUserSubjectByUser(int idUser)
    {
        HttpClient client = Utils.GetHttpClient();
        var query = HttpUtility.ParseQueryString(String.Empty);
        query["idUser"] = idUser.ToString();
        
        HttpResponseMessage response = await client.GetAsync($"{url}?{query}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
            
        var resp = response.Content.ReadAsStringAsync().Result;
        List<UserSubject> userSubjects = JsonConvert.DeserializeObject<List<UserSubject>>(resp);
        return userSubjects;
    }

    /// <summary>
    /// Método que faz a busca de todas associações do utilizador e disciplina por id da disciplina
    /// </summary>
    /// <param name="idUserSubject">id da disciplina</param>
    /// <returns>Retorna uma lista de todas associações disciplina-utilizador de uma determinada disciplina<</returns>
    public async Task<UserSubject> GetUserSubjectByUserSubject(int idUserSubject)
    {
        HttpClient client = Utils.GetHttpClient();
        var query = HttpUtility.ParseQueryString(String.Empty);
        query["idUserSubject"] = idUserSubject.ToString();
        
        HttpResponseMessage response = await client.GetAsync($"{url}?{query}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
            
        var resp = response.Content.ReadAsStringAsync().Result;
        List<UserSubject> userSubjects = JsonConvert.DeserializeObject<List<UserSubject>>(resp);
        UserSubject userSubject = null;
        if (userSubjects.Count > 0)
            userSubject = userSubjects[0];
        return userSubject;
    }
}