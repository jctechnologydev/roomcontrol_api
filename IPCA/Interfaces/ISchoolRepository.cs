using IPCA.Model;

namespace IPCA;

public interface ISchoolRepository
{
    public Task<List<School>> GetAllSchools();
}