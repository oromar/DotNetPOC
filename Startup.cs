using DotNetPOC.Interfaces;
using DotNetPOC.Service;
using DotNetPOC.Models;
using DotNetPOC.Business;


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DotNetPOC.Persistence;
using DotNetPOC.Utils;

namespace DotNetPOC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddDbContext<Persistence.UserAppContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddDbContext<Persistence.AuthContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("Auth")));

            services.AddMvc();

            services.AddTransient<IServiceUser, UserService>();
            services.AddTransient<IUserBO, UserBO>();
            services.AddTransient<IUserDAO, UserDAO>();
            services.AddTransient<IProgramGroupBO, ProgramGroupBO>();
            services.AddTransient<IProgramGroupDAO, ProgramGroupDAO>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
