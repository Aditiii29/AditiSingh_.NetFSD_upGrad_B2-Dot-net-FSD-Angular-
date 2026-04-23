using ContactManagementAPI.Models;

namespace ContactManagementAPI.Services
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact? GetById(int id);
        Contact Add(Contact contact);
        Contact? Update(int id, Contact contact);
        bool Delete(int id);
    }
}
