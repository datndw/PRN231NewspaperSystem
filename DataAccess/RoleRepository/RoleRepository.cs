
using System;
using BussinessObject.DbContexts;
using DataAccess.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.RoleRepository
{
    public class RoleRepository : GenericRepository<IdentityRole<Guid>>, IRoleRepository
    {
        public RoleRepository(NewspaperDbContext db) : base(db)
        {
        }
    }
}

