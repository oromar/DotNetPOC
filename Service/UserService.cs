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

        public UserService(AppContext context, IMapper mapper)
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

        public User Get(int userId)
        {
            return userBO.Get(userId);
        }

        public User Save(UserResource userResource)
        {
            var user = mapper.Map<UserResource, User>(userResource);
            return userBO.Save(user);
        }

        public User Update(int id, UserResource userResource)
        {
            var user = mapper.Map<UserResource, User>(userResource);
            return userBO.Update(id, user);
        }
    }
}