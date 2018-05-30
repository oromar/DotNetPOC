using DotNetPOC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static DotNetPOC.Utils.Utils;

namespace DotNetPOC.Persistence
{
    public class UserAppContext : DbContext
    {
        public UserAppContext(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; set; }

        public UserAppContext(DbContextOptions options, IConfiguration configuration)
        : base(options)
        {
            this.Configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Configuration.GetConnectionString(GetCurrentConnectionStringKey()));
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e => e.HasIndex(a => a.Email).IsUnique(true));
        }

        public DbSet<User> Users { get; set; }
    }
}