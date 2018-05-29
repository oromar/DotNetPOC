using System.Linq;
using System;
using DotNetPOC.Models;
using DotNetPOC.Persistence;
using System.Collections.Generic;

namespace DotNetPOC.Business
{
    public class UserBO
    {
        private readonly UsersDbContext context;

        public UserBO(UsersDbContext context)
        {
            this.context = context;
        }

        public User Save(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            context.Users.Remove(context.Users.Find(id));
            context.SaveChanges();
        }

        public User Update(int id, User user)
        {
            user.UserId = id;
            context.Users.Update(user);
            context.SaveChanges();
            return user;
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> Get()
        {
            return context.Users.ToList();
        }
    }
}