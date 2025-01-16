using IPCA.Model;

namespace IPCA;

public interface IScheduleRepository
{
    public Task<List<Schedule>> GetAllSchedules();
}