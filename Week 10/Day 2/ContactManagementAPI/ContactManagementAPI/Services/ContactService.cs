using ContactManagementAPI.Models;

namespace ContactManagementAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();
        private int _nextId = 1;

        public List<Contact> GetAll() => _contacts;

        public Contact? GetById(int id)
            => _contacts.FirstOrDefault(c => c.Id == id);

        public Contact Add(Contact contact)
        {
            contact.Id = _nextId++;
            _contacts.Add(contact);
            return contact;
        }

        public Contact? Update(int id, Contact contact)
        {
            var existing = GetById(id);
            if (existing == null) return null;
            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
            return existing;
        }

        public bool Delete(int id)
        {
            var contact = GetById(id);
            if (contact == null) return false;
            _contacts.Remove(contact);
            return true;
        }
    }
}
