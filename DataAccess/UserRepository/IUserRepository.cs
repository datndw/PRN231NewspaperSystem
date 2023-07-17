using System;
using BussinessObject.Models;
using DataAccess.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IList<IdentityRole<Guid>> GetRoles(Guid id);
        void AddRoles(Guid id, IList<Guid> roleIds);
        void DeleteRoles(Guid id);
    }
}

