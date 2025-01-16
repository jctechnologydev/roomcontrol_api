using DayOfWeek = IPCA.Model.DayOfWeek;

namespace IPCA;

public interface IDaysOfWeekRepository
{
    public Task<List<DayOfWeek>> GetAllDaysOfWeek();
}