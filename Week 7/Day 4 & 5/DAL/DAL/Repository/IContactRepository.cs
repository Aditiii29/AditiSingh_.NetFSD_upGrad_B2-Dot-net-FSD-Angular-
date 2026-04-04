using DAL.Model;

namespace DAL.Repository
{
    // Interface = contract
    // Controller uses this interface only
    // Never uses ContactRepository directly
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo? GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        // For dropdown lists in Add/Edit forms
        List<Company> GetAllCompanies();
        List<Department> GetAllDepartments();
    }
}