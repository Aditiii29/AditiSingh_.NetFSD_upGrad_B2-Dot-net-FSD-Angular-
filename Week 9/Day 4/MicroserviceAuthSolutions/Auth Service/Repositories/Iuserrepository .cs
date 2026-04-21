using Auth_Service.Models;

namespace Auth_Service.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<bool> EmailExistsAsync(string email);
    }
}
