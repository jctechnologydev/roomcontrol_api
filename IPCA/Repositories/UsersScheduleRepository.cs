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

internal class UsersScheduleRepository : IUserScheduleRepository
{
    private readonly string url = "usersSchedules";

    /// <summary>
    /// Método que faz busca de todos os utilizadores e as respetivas unidades curriculares
    /// </summary>
    /// <returns>Retorna uma lista de utilizadores e as unidades curriculares</returns>
    public async Task<List<UserSchedule>> GetAllUserSchedules()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<UserSchedule> userSchedules = JsonConvert.DeserializeObject<List<UserSchedule>>(resp);
        return userSchedules;
    }


    /// <summary>
    /// Método que faz a busca de todos dos horários (disciplina, utilizador)
    /// </summary>
    /// <param name="userSubject">id do utilizador, associado a disciplina</param>
    /// <returns>Retorna os Horários dos utilizadores</returns>
    public async Task<UserSchedule> GetUserSchedulesByUserSubject(int userSubject)
    {
        HttpClient client = Utils.GetHttpClient();
        var query = HttpUtility.ParseQueryString(String.Empty);
        query["idUserSubject"] = userSubject.ToString();

        
        HttpResponseMessage response = await client.GetAsync($"{url}?{query}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        var resp = response.Content.ReadAsStringAsync().Result;

        List<UserSchedule> userSchedules = JsonConvert.DeserializeObject<List<UserSchedule>>(resp);
        UserSchedule userSchedule = null;
        if (userSchedules.Count > 0)
            userSchedule = userSchedules[0];
        return userSchedule;
    }

    /// <summary>
    /// Método que faz a busca dos horários por id do utilizador
    /// </summary>
    /// <param name="idUser">id do utilizador</param>
    /// <returns>Retorna os horários de um determinado utilizador</returns>
    public async Task<List<UserSchedule>> GetUserSchedulesByUser(int idUser)
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
        
        List<UserSchedule> userSchedules = JsonConvert.DeserializeObject<List<UserSchedule>>(resp);
        return userSchedules;
    }
}