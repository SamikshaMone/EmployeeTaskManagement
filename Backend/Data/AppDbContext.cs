using Microsoft.EntityFrameworkCore;
using EmployeeTaskManagementSystem.Models;

namespace EmployeeTaskManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Set default value or constraints
            modelBuilder.Entity<TaskModel>()
                .Property(t => t.Status)
                .HasDefaultValue("Pending");

            // Optional: Unique email constraint
            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Seed roles or admin user (optional)
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 1,
                    FullName = "Admin User",
                    Email = "admin@company.com",
                    PasswordHash = Convert.ToBase64String(
                        System.Security.Cryptography.SHA256.Create().ComputeHash(
                            System.Text.Encoding.UTF8.GetBytes("Admin@123")
                        )),
                    Role = "Admin"
                }
            );
        }
    }
}
