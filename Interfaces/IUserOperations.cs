using DotNetPOC.Models;
using System.Collections.Generic;

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
}
