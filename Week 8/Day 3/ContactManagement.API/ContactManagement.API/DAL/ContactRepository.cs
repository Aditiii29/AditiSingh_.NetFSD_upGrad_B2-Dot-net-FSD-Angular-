using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>();
        private static int currentId = 1;

        public async Task<List<ContactInfo>> GetAllAsync()
        {
            return await Task.FromResult(contacts);
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }

        public async Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            contact.ContactId = currentId++;
            contacts.Add(contact);
            return await Task.FromResult(contact);
        }

        public async Task<bool> UpdateAsync(int id, ContactInfo contact)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);
            if (existing == null) return false;

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyId = contact.CompanyId;
            existing.DepartmentId = contact.DepartmentId;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact == null) return false;

            contacts.Remove(contact);
            return await Task.FromResult(true);
        }
    }
}