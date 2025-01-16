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
using DayOfWeek = IPCA.Model.DayOfWeek;

namespace IPCA;

internal class DaysOfWeekRepository : IDaysOfWeekRepository
{
    private readonly string url = "daysOfWeek";

    /// <summary>
    /// Método que faz a busca de todos os dias da semana em que há aulas
    /// </summary>
    /// <returns>Retorna uma lista de dias</returns>
    public async Task<List<DayOfWeek>> GetAllDaysOfWeek()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<DayOfWeek> daysOfWeek = JsonConvert.DeserializeObject<List<DayOfWeek>>(resp);
        return daysOfWeek;
    }
}