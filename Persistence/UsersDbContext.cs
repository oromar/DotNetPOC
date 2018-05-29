using DotNetPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetPOC.Persistence
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) 
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}