using System.Collections.Generic;
using AutoMapper;
using DotNetPOC.Business;
using DotNetPOC.Interfaces;
using DotNetPOC.Models;
using DotNetPOC.Persistence;
using DotNetPOC.Resources;

/*
    Class responsible to mapper resources to models and handle inter-features validations 
 */

namespace DotNetPOC.Service
{
    public class UserService : IServiceUser
    {
        private readonly UserBO userBO;
        private readonly IMapper mapper;

        public UserService(UserAppContext context, IMapper mapper)
        {
            this.userBO = new UserBO(context);
            this.mapper = mapper;
        }

        public void Delete(int id)
        {
            userBO.Delete(id);
        }

        public IEnumerable<UserResource> Get()
        {
            var users =  userBO.Get();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        }

        public UserResource Get(int userId)
        {
            var user = userBO.Get(userId);
            return mapper.Map<User, UserResource>(user);
        }

        public UserResource Save(UserResource userResource)
        {
            var user = mapper.Map<UserResource, User>(userResource);
            user = userBO.Save(user);
            return mapper.Map<User, UserResource>(user);
        }

        public UserResource Update(int id, UserResource userResource)
        {
            var user = mapper.Map<UserResource, User>(userResource);
            user.UserId = id;
            user = userBO.Update(id, user);
            return mapper.Map<User, UserResource>(user);
        }

        public IEnumerable<UserResource> Get(string name, string email, string login)
        {
            var users = userBO.Get(name, email, login);
            return mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        }
    }
}