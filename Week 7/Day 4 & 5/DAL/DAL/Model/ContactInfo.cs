using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    // This class = Contacts table in database
    public class ContactInfo
    {
        [Key] // Primary Key
        public int ContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailId { get; set; }

        public long MobileNo { get; set; }

        public string? Designation { get; set; }

        // Foreign Key - links to Company table
        [ForeignKey("CompanyData")]
        public int CompanyId { get; set; }

        // Foreign Key - links to Department table
        [ForeignKey("DepartmentData")]
        public int DepartmentId { get; set; }

        // Navigation Properties
        // Lets you access contact.CompanyData.CompanyName
        public virtual Company? CompanyData { get; set; }
        public virtual Department? DepartmentData { get; set; }
    }
}