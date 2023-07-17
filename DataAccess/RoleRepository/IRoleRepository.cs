using System;
using DataAccess.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.RoleRepository
{
    public interface IRoleRepository : IGenericRepository<IdentityRole<Guid>>
    {

    }
}

