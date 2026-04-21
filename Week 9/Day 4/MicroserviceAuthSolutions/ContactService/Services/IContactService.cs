using ContactService.DTOs;
using ContactService.Models;

namespace ContactService.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task<Contact> CreateAsync(ContactDTO dto);
        Task<Contact?> UpdateAsync(int id, ContactDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}