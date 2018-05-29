using System.Collections.Generic;
using DotNetPOC.Models;
using DotNetPOC.Resources;

namespace DotNetPOC.Interfaces
{
    public interface IServiceUser
    {
        User Save(UserResource user);
        User Update(int id, UserResource user);
        void Delete(int id);
        IEnumerable<UserResource> Get();
        User Get(int userId);
    }
}