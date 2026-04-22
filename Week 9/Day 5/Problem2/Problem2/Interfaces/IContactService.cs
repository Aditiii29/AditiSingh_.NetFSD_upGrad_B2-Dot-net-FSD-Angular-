using Problem2.Models;

namespace Problem2.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetContacts();
        bool RemoveContact(int id);
    }
}