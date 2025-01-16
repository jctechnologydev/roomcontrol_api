/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace IPCA;

public class Utils
{
    private static readonly string BaseURL = "http://localhost:3000/";
    //private static readonly string BaseURL = "https://a981-188-81-57-126.eu.ngrok.io";
    /// <summary>
    /// Método para acesso aos dados do IPCA (JsonServer)
    /// </summary>
    /// <returns></returns>
    public static HttpClient GetHttpClient(){ 
        HttpClient client = new HttpClient(); 
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.BaseAddress = new Uri(BaseURL);
        return client;
    }
}