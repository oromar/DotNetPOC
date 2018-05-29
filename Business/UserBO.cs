using System.Linq;
using System;
using DotNetPOC.Models;
using DotNetPOC.Persistence;
using System.Collections.Generic;
using DotNetPOC.Interfaces;

/*
    Class responsible to apply business rules
 */

namespace DotNetPOC.Business
{
    public class UserBO
    {
        private readonly UserDAO dao;

        public UserBO(Persistence.AppContext context)
        {
            this.dao = new UserDAO(context);
        }

        public User Save(User user)
        {
            return dao.Save(user);
        }

        public void Delete(int id)
        {
            dao.Delete(id);
        }

        public User Update(int id, User user)
        {
            user.UserId = id;
            return dao.Update(id, user);
        }

        public User Get(int id)
        {
            return dao.Get(id);
        }

        public IEnumerable<User> Get()
        {
            return dao.Get();
        }
    }
}