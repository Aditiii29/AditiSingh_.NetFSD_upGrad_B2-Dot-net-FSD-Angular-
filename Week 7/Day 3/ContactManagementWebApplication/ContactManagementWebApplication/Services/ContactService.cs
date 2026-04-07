using ContactManagementWebApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactManagementWebApplication.Services
{
    public class ContactService : IContactService
    {
        // Static list (allowed ONLY here)
        private static List<ContactInfo> contacts = new List<ContactInfo>();

        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }
    }
}
