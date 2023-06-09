using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.EF.Entities;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Infrastructure.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly SurveysDbContext _context;

        public UserRoleService(SurveysDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Users> GetAllUsers()
        {
            var userEntities = _context.Users.ToList();
            var users = userEntities.Select(u => new Users(u.Id, u.UserName, u.PasswordHash, GetUserRole(u.Id), u.Email));

            return users;
        }

        private string GetUserRole(int userId)
        {
            var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
            if (userRole != null)
            {
                var role = _context.Roles.FirstOrDefault(r => r.Id == userRole.RoleId);
                if (role != null)
                {
                    return role.Name;
                }
            }
            return null;
        }

        public void RemoveUserRole(int userId)
        {
            var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                _context.SaveChanges();
            }
        }

        public void AssignUserRole(int userId, string role)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var roleEntity = _context.Roles.FirstOrDefault(r => r.Name == role);
                if (roleEntity != null)
                {
                    var userRole = new Microsoft.AspNetCore.Identity.IdentityUserRole<int> { UserId = userId, RoleId = roleEntity.Id };
                    _context.UserRoles.Add(userRole);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Podana rola nie istnieje.");
                }
            }
        }
    }
}
