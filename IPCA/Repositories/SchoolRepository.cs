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

namespace IPCA;

internal class SchoolRepository : ISchoolRepository
{
    private readonly string url = "schools";

    /// <summary>
    /// Método que faz a buscca de todas as escolas do IPCA
    /// </summary>
    /// <returns>Retorna uma lista de escolas</returns>
    public async Task<List<School>> GetAllSchools()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<School> schools = JsonConvert.DeserializeObject<List<School>>(resp);
        return schools;
    }
}