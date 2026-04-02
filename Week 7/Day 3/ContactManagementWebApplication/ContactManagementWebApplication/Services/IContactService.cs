using ContactManagementWebApplication.Models;
using System.Collections.Generic;

namespace ContactManagementWebApplication.Services
{
    public interface IContactService
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
    }
}
