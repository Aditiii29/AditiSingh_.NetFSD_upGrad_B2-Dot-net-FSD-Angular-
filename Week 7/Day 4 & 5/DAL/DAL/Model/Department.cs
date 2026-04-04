using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    // This class = Departments table in database
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string? DepartmentName { get; set; }

        // One department can have many contacts
        public virtual ICollection<ContactInfo>? Contacts { get; set; }
    }
}