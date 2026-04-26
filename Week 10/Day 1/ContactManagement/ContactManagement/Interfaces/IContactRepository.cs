using ContactManagement.Models;

namespace ContactManagement.Interfaces
{
    /// <summary>
    /// Defines the contract for contact data operations.
    /// ✅ Interface name starts with 'I' — follows naming convention
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>Adds a new contact.</summary>
        void AddContact(Contact contact);

        /// <summary>Updates an existing contact by ID.</summary>
        bool UpdateContact(int id, string name, string email, string phone);

        /// <summary>Deletes a contact by ID.</summary>
        bool DeleteContact(int id);

        /// <summary>Returns all stored contacts.</summary>
        IEnumerable<Contact> GetAllContacts();
    }
}
