using IPCA.Model;

namespace IPCA;

public interface IClassroomRepository
{
    public Task<List<Classroom>> GetAllClassrooms();
    public Task<Classroom> GetClassroom(int idClassroom);
    public Task<List<Classroom>> GetClassroomFromSchool(int idSchool);
}