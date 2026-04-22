using Problem1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        bool DeleteContact(int id);
    }
}
