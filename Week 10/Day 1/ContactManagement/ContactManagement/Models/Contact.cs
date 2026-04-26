namespace ContactManagement.Models
{
    /// <summary>
    /// Represents a contact entity in the system.
    /// </summary>
    public class Contact
    {
        // ✅ PascalCase for public properties (CA1700, naming convention)
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;   // ✅ Avoid null with default

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Returns a readable summary of the contact.
        /// </summary>
        public override string ToString()
        {
            // ✅ No magic strings — clear formatting
            return $"[{Id}] {Name} | Email: {Email} | Phone: {Phone}";
        }
    }
}
