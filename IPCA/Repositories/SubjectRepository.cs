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

internal class SubjectRepository : ISubjectRepository
{
    private readonly string url = "subjects";

    /// <summary>
    /// M�todo que faz a busca de todas as unidades curriculares
    /// </summary>
    /// <returns>Retorna a lista de unidades currilares</returns>
    public async Task<List<SubjectIPCA>> GetAllSubjects()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<SubjectIPCA> subjects = JsonConvert.DeserializeObject<List<SubjectIPCA>>(resp);
        return subjects;
    }


    /// <summary>
    /// M�todo que faz a busca das unidades curiculares por id
    /// </summary>
    /// <param name="idSubject">id da unidade curricular</param>
    /// <returns>Retorna uma lista de unidades curriculares</returns>
    public async Task<SubjectIPCA> GetSubject(int idSubject)
    {
        HttpClient client = Utils.GetHttpClient();
        var query = HttpUtility.ParseQueryString(String.Empty);
        query["IdSubject"] = idSubject.ToString();
        
        HttpResponseMessage response = await client.GetAsync($"{url}?{query}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
            
        var resp = response.Content.ReadAsStringAsync().Result;
        List<SubjectIPCA> subjects = JsonConvert.DeserializeObject<List<SubjectIPCA>>(resp);
        SubjectIPCA subjectIpca = null;
        if (subjects.Count > 0)
            subjectIpca = subjects[0];
        return subjectIpca;
    }
}