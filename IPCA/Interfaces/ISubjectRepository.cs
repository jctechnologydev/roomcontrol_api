using IPCA.Model;

namespace IPCA;

public interface ISubjectRepository
{
    public Task<List<SubjectIPCA>> GetAllSubjects();
    public Task<SubjectIPCA> GetSubject(int idSubject);
}