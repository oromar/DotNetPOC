using DotNetPOC.Models;
using System.Collections.Generic;
using DotNetPOC.Resources;

namespace DotNetPOC.Interfaces
{
    public interface IUserOperations
    {
        User Save(User user);
        User Update(int id, User user);
        void Delete(int id);
        IEnumerable<User> Get();
        User Get(int userId);
        IEnumerable<User> Get(string name, string email, string login);
    }

    public interface IUserDAO : IUserOperations
    {

    }

    public interface IUserBO : IUserOperations
    {

    }
    
    public interface IServiceUser
    {
        UserResource Save(UserResource user);
        UserResource Update(int id, UserResource user);
        void Delete(int id);
        IEnumerable<UserResource> Get();
        UserResource Get(int userId);
        IEnumerable<UserResource> Get(string name, string email, string login);
    }

}
