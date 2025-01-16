/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using IPCA.Model;
using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace IPCA;

internal class ClassroomRepository : IClassroomRepository
{
    private readonly string url = "classrooms";

    /// <summary>
    /// M�todo que faz a busca de todas salas do IPCA
    /// </summary>
    /// <returns>Retorna uma lista de salas</returns>
    public async Task<List<Classroom>> GetAllClassrooms()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<Classroom> classrooms = JsonConvert.DeserializeObject<List<Classroom>>(resp);
        return classrooms;
    }

    /// <summary>
    /// M�todo que faz a busca de salas por id
    /// </summary>
    /// <param name="idClassroom">id da sala</param>
    /// <returns>Retorna a encontrada sala</returns>
    public async Task<Classroom> GetClassroom(int idClassroom)
    {
        HttpClient client = Utils.GetHttpClient();

        var query = HttpUtility.ParseQueryString(String.Empty);
        query["IdClassroom"] = idClassroom.ToString();

        HttpResponseMessage response = await client.GetAsync($"{url}?{query}");
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        string resp = response.Content.ReadAsStringAsync().Result;

        List<Classroom> classrooms = JsonConvert.DeserializeObject<List<Classroom>>(resp);
        Classroom classroom = null;
        if (classrooms.Count > 0)
            classroom = classrooms[0];
        return classroom;
    }

    public async Task<List<Classroom>> GetClassroomFromSchool(int idSchool)
    {
        HttpClient client = Utils.GetHttpClient();

        var query = HttpUtility.ParseQueryString(String.Empty);
        query["IdSchool"] = idSchool.ToString();

        HttpResponseMessage response = await client.GetAsync($"{url}?{query}");
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        string resp = response.Content.ReadAsStringAsync().Result;

        List<Classroom> classrooms = JsonConvert.DeserializeObject<List<Classroom>>(resp);
        return classrooms;
    }
}