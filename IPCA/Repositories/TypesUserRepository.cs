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

internal class TypesUserRepository : ITypeUserRepository
{
    private readonly string url = "typesUsers";

    /// <summary>
    /// Método que faz a busca de todos tipos de utilizadores no sistema do IPCA
    /// </summary>
    /// <returns>Retorna uma lista de tipos de utilizadores</returns>
    public async Task<List<TypeUser>> GetAllTypesOfUser()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<TypeUser> typeUsers = JsonConvert.DeserializeObject<List<TypeUser>>(resp);
        return typeUsers;
    }
}