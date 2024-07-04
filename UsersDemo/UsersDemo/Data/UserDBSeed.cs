using UsersDemo.Models;

namespace UsersDemo.Data
{
    public class UserDBSeed
    {
        public static async void SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<UserDBContext>();
            dbContext.Database.EnsureCreated();
            if (!dbContext.Users.Any())
            {
                var users = new List<User>()
                    {
                        new() { Id = 1, Name = "Test User", Age = 13, Value = 12.45M, DateTime = DateTime.UtcNow.AddYears(-5), Active = true },
                        new() { Id = 2, Name = "Home User", Age = 27, Value = 85.12M,  DateTime = DateTime.UtcNow, Active = true },
                        new() { Id = 3, Name = "Work User", Age = 45, Value = 1.82M, DateTime = DateTime.UtcNow , Active = false }
                    };
                await dbContext.AddRangeAsync(users);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}