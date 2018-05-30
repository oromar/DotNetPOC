using DotNetPOC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using DotNetPOC.Utils;

namespace DotNetPOC.Persistence
{
    public class UserAppContext : DbContext
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpAccessor;

        public UserAppContext(IConfiguration configuration, IHttpContextAccessor httpAccessor)
        {
            this.configuration = configuration;
            this.httpAccessor = httpAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionStringKey = "Default";
            
            if (httpAccessor != null && httpAccessor.HttpContext !=null && httpAccessor.HttpContext.Items[Constants.ConnectionString] != null) 
                connectionStringKey = httpAccessor.HttpContext.Items[Constants.ConnectionString].ToString();

            builder.UseSqlServer(configuration.GetConnectionString(connectionStringKey));

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e => e.HasIndex(a => a.Email).IsUnique(true));
        }

        public DbSet<User> Users { get; set; }
    }
}