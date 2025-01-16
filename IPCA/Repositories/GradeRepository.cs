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

internal class GradeRepository : IGradeRepository
{
    private readonly string url = "grades";

    /// <summary>
    /// Método que faz a busca de todos os anos curriculares
    /// </summary>
    /// <returns>Retorna uma lista dos anos</returns>
    public async Task<List<Grade>> GetAllGrades()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<Grade> grades = JsonConvert.DeserializeObject<List<Grade>>(resp);
        return grades;
    }
}