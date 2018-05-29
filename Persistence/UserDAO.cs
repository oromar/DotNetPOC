using System.Collections.Generic;
using System.Linq;
using DotNetPOC.Interfaces;
using DotNetPOC.Models;

/*
    Class responsible to data access
 */

namespace DotNetPOC.Persistence
{
    public class UserDAO
    {
        private readonly AppContext context;

        public UserDAO(AppContext context)
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
    }
}