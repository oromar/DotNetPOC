using DotNetPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetPOC.Persistence
{
    public class UserAppContext : DbContext
    {
        public UserAppContext(DbContextOptions options) 
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<User>(e => e.HasIndex(a => a.Email).IsUnique(true));
        }

        public DbSet<User> Users { get; set; }
    }
}