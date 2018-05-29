using System.Collections.Generic;
using DotNetPOC.Models;
using DotNetPOC.Resources;

namespace DotNetPOC.Interfaces
{
    public interface IServiceUser
    {
        UserResource Save(UserResource user);
        UserResource Update(int id, UserResource user);
        void Delete(int id);
        IEnumerable<UserResource> Get();
        UserResource Get(int userId);
    }
}