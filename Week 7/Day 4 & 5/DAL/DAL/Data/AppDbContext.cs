using Microsoft.EntityFrameworkCore;
using DAL.Model;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor for Dependency Injection (used by Program.cs)
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Constructor for Migrations (used by Package Manager Console)
        public AppDbContext()
        {
        }

        // Each DbSet = one table in database
        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        // Called when no options are passed (migrations)
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            // Only runs if not already configured by Program.cs
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=localhost\SQLEXPRESS;
                      Database=ContactManagementDB;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;"
                );
            }
        }

        // Defines relationships between tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One Company → Many Contacts
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.CompanyData)
                .WithMany(co => co.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Department → Many Contacts
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.DepartmentData)
                .WithMany(d => d.Contacts)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data - inserted when database is first created
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, CompanyName = "ABC Infotech" },
                new Company { CompanyId = 2, CompanyName = "XYZ Solutions" },
                new Company { CompanyId = 3, CompanyName = "Tech Corp" }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" }
            );
        }
    }
}