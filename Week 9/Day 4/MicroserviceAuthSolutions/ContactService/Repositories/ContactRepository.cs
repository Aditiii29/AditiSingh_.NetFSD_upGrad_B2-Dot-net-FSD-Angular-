using Microsoft.EntityFrameworkCore;
using ContactService.Data;
using ContactService.Models;

namespace ContactService.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
            => await _context.Contacts.ToListAsync();

        public async Task<Contact?> GetByIdAsync(int id)
            => await _context.Contacts.FindAsync(id);

        public async Task<Contact> CreateAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact?> UpdateAsync(int id, Contact updated)
        {
            var existing = await _context.Contacts.FindAsync(id);
            if (existing == null) return null;

            existing.Name = updated.Name;
            existing.Email = updated.Email;
            existing.Phone = updated.Phone;
            existing.CategoryId = updated.CategoryId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null) return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}