using IPCA.Model;

namespace IPCA;

public interface ICourseRepository
{
    public Task<List<Course>> GetAllCourses();
    public Task<Course> GetCoursesById(int idCourse);
}