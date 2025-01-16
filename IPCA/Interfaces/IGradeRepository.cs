using IPCA.Model;

namespace IPCA;

public interface IGradeRepository
{
    public Task<List<Grade>> GetAllGrades();
}