using System.Collections.Generic;
using System.Linq;
using DotNetPOC.Interfaces;
using DotNetPOC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

/*
    Class responsible to data access
 */

namespace DotNetPOC.Persistence
{
    public class UserDAO : IUserDAO
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpAccessor;

        public UserDAO(IConfiguration configuration, IHttpContextAccessor httpAccessor)
        {
            this.configuration = configuration;
            this.httpAccessor = httpAccessor;
        }
        public void Delete(int id)
        {
            using(var context = new UserAppContext(configuration, httpAccessor))
            {
                context.Users.Remove(context.Users.Find(id));
                context.SaveChanges();    
            }
        }
        public IEnumerable<User> Get()
        {
            using(var context = new UserAppContext(configuration, httpAccessor))
            {
                return context.Users.ToList();
            }
        }
        public User Get(int userId)
        {
            using(var context = new UserAppContext(configuration, httpAccessor))
            {
                return context.Users.Find(userId);
            }
        }
        public User Save(User user)
        {
            using(var context = new UserAppContext(configuration, httpAccessor))
            {
                context.Users.Add(user);
                context.SaveChanges();            
                return user;
            }
        }
        public User Update(int id, User user)
        {
            using(var context = new UserAppContext(configuration, httpAccessor))
            {
                context.Users.Update(user);
                context.SaveChanges();
                return user;
            }
        }
        public IEnumerable<User> Get(string name, string email, string login)
        {
            using(var context = new UserAppContext(configuration, httpAccessor))
            {
                return context.Users.Where(a => string.IsNullOrEmpty(name) || a.Name.Contains(name))
                                    .Where(a => string.IsNullOrEmpty(email) || a.Email.Contains(email))
                                    .Where(a => string.IsNullOrEmpty(login) || a.Login.Contains(login))
                                    .ToList();
            }
        }
    }
}