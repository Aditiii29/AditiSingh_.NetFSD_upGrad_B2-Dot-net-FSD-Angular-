using ContactService.DTOs;
using ContactService.Models;
using ContactService.Repositories;

namespace ContactService.Services
{
    public class ContactServiceImpl : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactServiceImpl(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<Contact?> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<Contact> CreateAsync(ContactDTO dto)
        {
            var contact = new Contact
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                CategoryId = dto.CategoryId
            };
            return await _repository.CreateAsync(contact);
        }

        public async Task<Contact?> UpdateAsync(int id, ContactDTO dto)
        {
            var contact = new Contact
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                CategoryId = dto.CategoryId
            };
            return await _repository.UpdateAsync(id, contact);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}