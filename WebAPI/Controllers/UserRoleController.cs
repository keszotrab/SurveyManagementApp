using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles = "Admin")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            IEnumerable<UserWithRoleDto> users = _userRoleService.GetAllUsers().Select(UserWithRoleDto.of).AsEnumerable();
            return Ok(users);
        }

        [HttpPost("{id}/roles")]
        public IActionResult AssignUserRole(int id, string role)
        {
            try
            {
                _userRoleService.AssignUserRole(id, role);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}/roles")]
        public IActionResult DeleteUserRole(int id)
        {
            _userRoleService.RemoveUserRole(id);
            return NoContent();
        }
    }
}
