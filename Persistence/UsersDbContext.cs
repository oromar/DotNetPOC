using DotNetPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetPOC.Persistence
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) 
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}