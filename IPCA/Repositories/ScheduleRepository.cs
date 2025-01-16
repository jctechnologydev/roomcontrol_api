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

public class ScheduleRepository : IScheduleRepository
{
    private readonly string url = "schedules";

    /// <summary>
    /// Método que faz a busca de todos os horários do IPCA
    /// </summary>
    /// <returns>Retorna a lista dos horários</returns>
    public async Task<List<Schedule>> GetAllSchedules()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<Schedule> schedules = JsonConvert.DeserializeObject<List<Schedule>>(resp);
        return schedules;
    }
}