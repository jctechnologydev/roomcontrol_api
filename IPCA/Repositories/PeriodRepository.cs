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

internal class PeriodRepository : IPeriodRepository
{
    private readonly string url = "periods";

    /// <summary>
    /// M�todo que faz a pesquisa de todos os per�odos de aulas (Laboral e P�s-Laborall)
    /// </summary>
    /// <returns>Retorna uma lista de per�odos</returns>
    public async Task<List<Period>> GetAllPeriods()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<Period> periods = JsonConvert.DeserializeObject<List<Period>>(resp);
        return periods;
    }
}