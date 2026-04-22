using Problem1.Interfaces;
using Problem1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Services
{
    public class ContactService : IContactService
    {
        // In-memory storage — a simple list acts as our "database"
        private readonly List<Contact> _contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContactById(int id)
        {
            // FirstOrDefault returns null if not found — safe to use
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public bool DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
                return true;   // deleted successfully
            }
            return false;      // contact not found
        }
    }

}
