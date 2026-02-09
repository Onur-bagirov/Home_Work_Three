using EShopp.Domain.Entities;

namespace EShopp.Aplication.Abstacts
{
    public interface  IUserService
    {
        Task RegisterAsync(User user);
        Task<User?> LoginAsync(string username, string userpassword);
        Task<List<User>> GetAllAsync();
    }
}
