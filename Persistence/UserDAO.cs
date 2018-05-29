using System.Collections.Generic;
using System.Linq;
using DotNetPOC.Interfaces;
using DotNetPOC.Models;

/*
    Class responsible to data access
 */

namespace DotNetPOC.Persistence
{
    public class UserDAO : IUserDAO
    {
        private readonly UserAppContext context;

        public UserDAO(UserAppContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.Users.Remove(context.Users.Find(id));
            context.SaveChanges();
        }

        public IEnumerable<User> Get()
        {
            return context.Users.ToList();
        }

        public User Get(int userId)
        {
            return context.Users.Find(userId);
        }

        public User Save(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();            
            return user;
        }

        public User Update(int id, User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
            return user;
        }

        public IEnumerable<User> Get(string name, string email, string login)
        {
            return context.Users.Where(a => string.IsNullOrEmpty(name) || a.Name.Contains(name))
                                .Where(a => string.IsNullOrEmpty(email) || a.Email.Contains(email))
                                .Where(a => string.IsNullOrEmpty(login) || a.Login.Contains(login))
                                .ToList();
        }
    }
}