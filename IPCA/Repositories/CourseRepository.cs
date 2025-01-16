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

internal class CourseRepository : ICourseRepository
{
    private readonly string url = "courses";

    /// <summary>
    /// Método que faz a busca de todas salas do IPCA
    /// </summary>
    /// <returns>Retorna todos os cursos</returns>
    public async Task<List<Course>> GetAllCourses()
    {
        HttpClient client = Utils.GetHttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        var resp = response.Content.ReadAsStringAsync().Result;

        List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(resp);
        return courses;
    }

    /// <summary>
    /// Método que faz a pesquisa do curso por id
    /// </summary>
    /// <param name="idCourse">id do curso</param>
    /// <returns>Retorna o curso encontrado</returns>
    public async Task<Course> GetCoursesById(int idCourse)
    {
        HttpClient client = Utils.GetHttpClient();
        var query = HttpUtility.ParseQueryString(String.Empty);
        query["idGrade"] = idCourse.ToString();

        
        HttpResponseMessage response = await client.GetAsync($"{url}?{query}");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        var resp = response.Content.ReadAsStringAsync().Result;

        List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(resp);
        Course course = null;
        if (courses.Count > 0)
            course = courses[0];
        return course;
    }
}