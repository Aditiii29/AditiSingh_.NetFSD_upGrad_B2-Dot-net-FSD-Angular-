using Problem2.Interfaces;     
using Problem2.Models;         
using Problem2.Repositories;

namespace Problem2.Services
{
    public class ContactService : IContactService
    {
        // Service DEPENDS on repository — injected via constructor
        private readonly IContactRepository _repository;

        // Constructor Injection — repository is passed in from outside
        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public void AddContact(Contact contact)
        {
            // Business rule: Name cannot be empty
            if (string.IsNullOrEmpty(contact.Name))
            {
                throw new ArgumentException("Contact name cannot be empty");
            }

            _repository.Add(contact);
        }

        public List<Contact> GetContacts()
        {
            return _repository.GetAll();
        }

        public bool RemoveContact(int id)
        {
            return _repository.Remove(id);
        }
    }
}
