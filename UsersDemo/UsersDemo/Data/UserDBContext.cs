using Microsoft.EntityFrameworkCore;
using UsersDemo.Models;

namespace UsersDemo.Data
{
    public class UserDBContext(DbContextOptions<UserDBContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
