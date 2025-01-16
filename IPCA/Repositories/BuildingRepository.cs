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

internal class BuildingRepository : IBuildingRepository
{
    private readonly string url = "buildings";

    /// <summary>
    /// Método que faz a busca dos edificios do IPCA
    /// </summary>
    /// <returns>Retorna uma lista de edificios</returns>
    public async Task<List<Building>> GetAllBuildings()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<Building> buildings = JsonConvert.DeserializeObject<List<Building>>(resp);
        return buildings;
    }
}