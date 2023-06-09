using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserRoleService
    {
        // id, username, email, role
        
        public IEnumerable<Users> GetAllUsers();
        public void RemoveUserRole(int userId);
        public void AssignUserRole(int userId, string role);

    }   
}
