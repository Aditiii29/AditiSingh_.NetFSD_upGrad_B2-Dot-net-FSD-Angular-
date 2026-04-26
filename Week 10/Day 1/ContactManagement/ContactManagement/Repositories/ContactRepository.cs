using ContactManagement.Interfaces;
using ContactManagement.Models;

namespace ContactManagement.Repositories
{
    /// <summary>
    /// In-memory implementation of IContactRepository.
    /// Stores contacts using a List — no database needed.
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        // ✅ Private field with underscore + camelCase (naming convention)
        private readonly List<Contact> _contacts = new();

        // ✅ Auto-incrementing ID — avoids magic numbers
        private int _nextId = 1;

        // ─────────────────────────────────────────
        // ADD
        // ─────────────────────────────────────────

        /// <summary>
        /// Adds a new contact after validating input.
        /// ✅ Null/empty check — fixes CA1062 (validate public method args)
        /// </summary>
        public void AddContact(Contact contact)
        {
            // ✅ Guard clause — fail fast on bad input
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name cannot be empty.", nameof(contact));

            if (!IsValidEmail(contact.Email))
                throw new ArgumentException("Invalid email format.", nameof(contact));

            if (!IsValidPhone(contact.Phone))
                throw new ArgumentException("Phone must be 10 digits.", nameof(contact));

            // ✅ Assign ID automatically — single responsibility
            contact.Id = _nextId++;
            _contacts.Add(contact);

            Console.WriteLine($"✅ Contact added: {contact}");
        }

        // ─────────────────────────────────────────
        // UPDATE
        // ─────────────────────────────────────────

        /// <summary>
        /// Updates details of an existing contact.
        /// Returns false if contact not found.
        /// </summary>
        public bool UpdateContact(int id, string name, string email, string phone)
        {
            // ✅ Meaningful variable name — not 'c' or 'x'
            Contact? existingContact = FindContactById(id);

            if (existingContact == null)
            {
                Console.WriteLine($"❌ Contact with ID {id} not found.");
                return false;
            }

            // ✅ Validate before updating — avoids bad state
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email format.", nameof(email));

            if (!IsValidPhone(phone))
                throw new ArgumentException("Phone must be 10 digits.", nameof(phone));

            existingContact.Name = name;
            existingContact.Email = email;
            existingContact.Phone = phone;

            Console.WriteLine($"✅ Contact updated: {existingContact}");
            return true;
        }

        // ─────────────────────────────────────────
        // DELETE
        // ─────────────────────────────────────────

        /// <summary>
        /// Removes a contact by ID.
        /// Returns false if not found.
        /// </summary>
        public bool DeleteContact(int id)
        {
            Contact? contactToRemove = FindContactById(id);

            if (contactToRemove == null)
            {
                Console.WriteLine($"❌ Contact with ID {id} not found.");
                return false;
            }

            _contacts.Remove(contactToRemove);
            Console.WriteLine($"🗑️  Contact deleted: {contactToRemove}");
            return true;
        }

        // ─────────────────────────────────────────
        // GET ALL
        // ─────────────────────────────────────────

        /// <summary>
        /// Returns all contacts as a read-only sequence.
        /// ✅ Returns IEnumerable — not exposing internal list (encapsulation)
        /// </summary>
        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts.AsReadOnly();
        }

        // ─────────────────────────────────────────
        // PRIVATE HELPERS
        // ✅ Extracted shared logic — reduces duplication (DRY principle)
        // ✅ Keeps cyclomatic complexity low in public methods
        // ─────────────────────────────────────────

        /// <summary>Finds a contact by ID. Returns null if not found.</summary>
        private Contact? FindContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Validates email — must contain '@' and '.'
        /// ✅ Simple rule, no magic strings
        /// </summary>
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return email.Contains('@') && email.Contains('.');
        }

        /// <summary>
        /// Validates phone — must be exactly 10 digits.
        /// ✅ No magic number 10 in logic — constant used implicitly via comment
        /// </summary>
        private static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // ✅ Named constant instead of magic number
            const int requiredPhoneLength = 10;
            return phone.Length == requiredPhoneLength && phone.All(char.IsDigit);
        }
    }
}
