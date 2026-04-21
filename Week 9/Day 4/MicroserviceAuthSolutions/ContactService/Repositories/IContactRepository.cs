using ContactService.Models;

namespace ContactService.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task<Contact> CreateAsync(Contact contact);
        Task<Contact?> UpdateAsync(int id, Contact contact);
        Task<bool> DeleteAsync(int id);
    }
}