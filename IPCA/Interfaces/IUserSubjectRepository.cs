using IPCA.Model;

namespace IPCA;

public interface IUserSubjectRepository
{
    public Task<List<UserSubject>> GetAllUserSubject();
    public Task<List<UserSubject>> GetUserSubjectByUser(int idUser);
    public Task<UserSubject> GetUserSubjectByUserSubject(int idUserSubject);
}