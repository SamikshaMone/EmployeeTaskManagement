using EmployeeTaskManagementSystem.Models;

namespace EmployeeTaskManagementSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if there are any users already
            if (context.Users.Any())
                return; // DB has been seeded

            var users = new List<UserModel>
            {
                new UserModel
                {
                    FullName = "John Manager",
                    Email = "manager@company.com",
                    PasswordHash = Hash("Manager123"),
                    Role = "Manager"
                },
                new UserModel
                {
                    FullName = "Emily Employee",
                    Email = "employee@company.com",
                    PasswordHash = Hash("Employee123"),
                    Role = "Employee"
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static string Hash(string password)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
