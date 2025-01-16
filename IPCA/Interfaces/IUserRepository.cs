using IPCA.Model;

namespace IPCA;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsers();
    public Task<User> Login(string user, string password);
}