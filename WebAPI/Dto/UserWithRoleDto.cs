using ApplicationCore.Models;

namespace WebAPI.Dto
{
    public class UserWithRoleDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public static UserWithRoleDto of(Users users)
        {
            if (users == null)
            {
                return null;
            }
            else
            {
                return new UserWithRoleDto()
                {
                    UserId = users.Id,
                    UserName = users.Username,
                    Email = users.Email,
                    Role = users.Role
                };
            }
        }
    }

}
