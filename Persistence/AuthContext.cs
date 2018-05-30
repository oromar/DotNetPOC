using DotNetPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetPOC.Persistence
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }
        public DbSet<ProgramGroup> ProgramGroups { get; set; }
        public DbSet<AppStatus> AppStatus { get; set; }
        
    }
}