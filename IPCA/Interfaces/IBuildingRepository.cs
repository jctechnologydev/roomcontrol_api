using IPCA.Model;

namespace IPCA;

public interface IBuildingRepository
{
    public Task<List<Building>> GetAllBuildings();
}