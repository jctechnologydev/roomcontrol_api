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

public class UserRepository : IUserRepository
{
    
    private readonly string url = "users";

    /// <summary>
    /// Método que faz a busca de todos os utilizadores do sistema
    /// </summary>
    /// <returns>Retorna uma lista de utilizadores</returns>
    public async Task<List<User>> GetAllUsers()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<User> users = JsonConvert.DeserializeObject<List<User>>(resp);
        return users;
    }

    /// <summary>
    /// Método para iniciar a sessão no sistema
    /// </summary>
    /// <param name="user">email do utilizador</param>
    /// <param name="password">palavrapasse do utilizador</param>
    /// <returns>Retorna o utilizador associado as credênciais inseridas</returns>
    public async Task<User> Login(string user, string password)
    {
        HttpClient client = Utils.GetHttpClient();
        var query = HttpUtility.ParseQueryString(String.Empty);
        query["email"] = user;
        query["password"] = password;

        
        HttpResponseMessage response = await client.GetAsync($"{url}?{query}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        var resp = response.Content.ReadAsStringAsync().Result;
        
        List<User> listUsers = JsonConvert.DeserializeObject<List<User>>(resp);
        if (listUsers.Count == 0)
            return null;
        return listUsers[0];
    }
}