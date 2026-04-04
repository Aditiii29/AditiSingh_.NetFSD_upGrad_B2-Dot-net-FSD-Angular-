using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    // This class = Companies table in database
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string? CompanyName { get; set; }

        // One company can have many contacts
        public virtual ICollection<ContactInfo>? Contacts { get; set; }
    }
}