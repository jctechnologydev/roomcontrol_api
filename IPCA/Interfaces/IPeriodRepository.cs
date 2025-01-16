using IPCA.Model;

namespace IPCA;

public interface IPeriodRepository
{
    public Task<List<Period>> GetAllPeriods();
}