using IPCA.Model;

namespace IPCA;

public interface ITypeUserRepository
{
    public Task<List<TypeUser>> GetAllTypesOfUser();
}