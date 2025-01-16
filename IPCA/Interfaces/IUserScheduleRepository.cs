using IPCA.Model;

namespace IPCA;

public interface IUserScheduleRepository
{
    public Task<List<UserSchedule>> GetAllUserSchedules();
    public Task<UserSchedule> GetUserSchedulesByUserSubject(int userSubject);
}