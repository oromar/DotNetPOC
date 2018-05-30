using DotNetPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetPOC.Persistence
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ProgramGroup> ProgramGroups { get; set; }
    }
}