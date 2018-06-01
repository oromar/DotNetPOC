using DotNetPOC.Interfaces;
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
using DotNetPOC.Filters;
using Microsoft.AspNetCore.Http;
using DotNetPOC.Domain;
using Swashbuckle.AspNetCore.Swagger;

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
                    options => options.UseSqlServer(Configuration.GetConnectionString("Default")),
                    ServiceLifetime.Transient,
                    ServiceLifetime.Transient);

            services.AddDbContext<Persistence.AuthContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("Auth")),
                    ServiceLifetime.Transient,
                    ServiceLifetime.Transient);

            services.AddMvc();

            services.AddTransient<IDomainUser, UserDomain>();
            services.AddTransient<IUserBO, UserBO>();
            services.AddTransient<IUserDAO, UserDAO>();
            services.AddTransient<IProgramGroupDomain, ProgramGroupDomain>();
            services.AddTransient<IProgramGroupBO, ProgramGroupBO>();
            services.AddTransient<IProgramGroupDAO, ProgramGroupDAO>();
            services.AddTransient<AuthorizationFilter>();

            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "SmartSchools Server"                        
                    });
                    c.IncludeXmlComments(@"bin\Debug\netcoreapp2.0\DotNetPOC.xml");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartSchools v1");                                
            });

            app.UseMvc();
        }
    }
}
