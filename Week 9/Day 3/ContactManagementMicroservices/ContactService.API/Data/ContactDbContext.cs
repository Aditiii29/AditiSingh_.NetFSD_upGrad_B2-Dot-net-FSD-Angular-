using Microsoft.EntityFrameworkCore;
using ContactService.API.Models;

namespace ContactService.API.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
