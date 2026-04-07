using DAL.Data;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    // Implements IContactRepository
    // Contains all actual database logic
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _db;

        // AppDbContext injected automatically by DI
        public ContactRepository(AppDbContext db)
        {
            _db = db;
        }

        // Get all contacts with Company and Department names
        // Include() = JOIN in SQL
        public List<ContactInfo> GetAllContacts()
        {
            return _db.Contacts
                      .Include(c => c.CompanyData)
                      .Include(c => c.DepartmentData)
                      .ToList();
        }

        // Get single contact by ID
        public ContactInfo? GetContactById(int id)
        {
            return _db.Contacts
                      .Include(c => c.CompanyData)
                      .Include(c => c.DepartmentData)
                      .FirstOrDefault(c => c.ContactId == id);
        }

        // Insert new contact into database
        public void AddContact(ContactInfo contact)
        {
            _db.Contacts.Add(contact);
            _db.SaveChanges();
        }

        // Update existing contact in database
        public void UpdateContact(ContactInfo contact)
        {
            _db.Contacts.Update(contact);
            _db.SaveChanges();
        }

        // Delete contact from database
        public void DeleteContact(int id)
        {
            var contact = _db.Contacts.Find(id);
            if (contact != null)
            {
                _db.Contacts.Remove(contact);
                _db.SaveChanges();
            }
        }

        // Get all companies for dropdown
        public List<Company> GetAllCompanies()
        {
            return _db.Companies.ToList();
        }

        // Get all departments for dropdown
        public List<Department> GetAllDepartments()
        {
            return _db.Departments.ToList();
        }
    }
}