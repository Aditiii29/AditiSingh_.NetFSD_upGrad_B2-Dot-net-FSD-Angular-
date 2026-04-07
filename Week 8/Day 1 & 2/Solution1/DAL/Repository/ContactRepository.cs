using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using DAL.Models;

namespace DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;

        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        // 🔹 Get All Contacts (with JOIN)
        public List<ContactInfo> GetAllContacts()
        {
            string query = @"SELECT c.*, comp.CompanyName, d.DepartmentName
                             FROM ContactInfo c
                             JOIN Company comp ON c.CompanyId = comp.CompanyId
                             JOIN Department d ON c.DepartmentId = d.DepartmentId";

            using (IDbConnection connection = _context.CreateConnection())
            {
                return connection.Query<ContactInfo>(query).ToList();
            }
        }

        // 🔹 Get Contact By Id
        public ContactInfo GetContactById(int id)
        {
            string query = "SELECT * FROM ContactInfo WHERE ContactId = @Id";

            using (IDbConnection connection = _context.CreateConnection())
            {
                return connection.QueryFirstOrDefault<ContactInfo>(query, new { Id = id });
            }
        }

        // 🔹 Add Contact
        public void AddContact(ContactInfo contact)
        {
            string query = @"INSERT INTO ContactInfo 
                            (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                            VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Execute(query, contact);
            }
        }

        // 🔹 Update Contact
        public void UpdateContact(ContactInfo contact)
        {
            string query = @"UPDATE ContactInfo SET 
                            FirstName = @FirstName,
                            LastName = @LastName,
                            EmailId = @EmailId,
                            MobileNo = @MobileNo,
                            Designation = @Designation,
                            CompanyId = @CompanyId,
                            DepartmentId = @DepartmentId
                            WHERE ContactId = @ContactId";

            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Execute(query, contact);
            }
        }

        // 🔹 Delete Contact
        public void DeleteContact(int id)
        {
            string query = "DELETE FROM ContactInfo WHERE ContactId = @Id";

            using (IDbConnection connection = _context.CreateConnection())
            {
                connection.Execute(query, new { Id = id });
            }
        }

        // 🔹 Get Companies (Dropdown)
        public List<Company> GetCompanies()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return connection.Query<Company>("SELECT * FROM Company").ToList();
            }
        }

        // 🔹 Get Departments (Dropdown)
        public List<Department> GetDepartments()
        {
            using (IDbConnection connection = _context.CreateConnection())
            {
                return connection.Query<Department>("SELECT * FROM Department").ToList();
            }
        }
    }
}