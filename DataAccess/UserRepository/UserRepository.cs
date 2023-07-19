using System;
using DataAccess.DbContexts;
using BussinessObject.Models;
using DataAccess.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(NewspaperDbContext db) : base(db)
        {
        }

        public IList<IdentityRole<Guid>> GetRoles(Guid id)
        {
            var roleIds = _db.UserRoles.Where(ur => ur.UserId == id).Select(ur => ur.RoleId).ToList();
            return _db.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
        }
        public void AddRoles(Guid id, IList<Guid> roleIds)
        {
            var userRoles = roleIds.Select(roleId => new IdentityUserRole<Guid>
            {
                UserId = id,
                RoleId = roleId
            });
            _db.UserRoles.AddRange(userRoles);
        }

        public void DeleteRoles(Guid id)
        {
            _db.UserRoles.RemoveRange(_db.UserRoles.Where(ur => ur.UserId == id));
        }
    }
}

