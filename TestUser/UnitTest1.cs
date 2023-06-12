using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebAPI.Controllers;
using WebAPI.Dto;

namespace WebAPI.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserRoleController _controller;
        private Mock<IUserRoleService> _userRoleServiceMock;

        [SetUp]
        public void Setup()
        {
            _userRoleServiceMock = new Mock<IUserRoleService>();
            _controller = new UserRoleController(_userRoleServiceMock.Object);
        }

        [Test]
        public void GetAllUsers_WithUserRoleService_ReturnsOkResultWithUsers()
        {
            // Arrange
            var users = new List<Users>()
            {
                new Users(1, "User1", "User1!", "User", "user1@gmail.com"),
                new Users(2, "User2", "User2!", "User", "user2@gmail.com"),
                new Users(3, "User3", "User3!", "User", "user3@gmail.com")
            };

            _userRoleServiceMock.Setup(s => s.GetAllUsers()).Returns(users);

            // Act
            var result = _controller.GetAllUsers();

            // Assert
            NUnit.Framework.Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            NUnit.Framework.Assert.IsInstanceOf<IEnumerable<UserWithRoleDto>>(okResult.Value);

            var usersDto = (IEnumerable<UserWithRoleDto>)okResult.Value;
            NUnit.Framework.Assert.AreEqual(users.Count(), usersDto.Count());
        }

        [Test]
        public void AssignUserRole_ValidData_ReturnsOkResult()
        {
            // Arrange
            var id = 1;
            var role = "Admin";

            // Act
            var result = _controller.AssignUserRole(id, role);

            // Assert
            NUnit.Framework.Assert.IsInstanceOf<OkResult>(result);
            _userRoleServiceMock.Verify(s => s.AssignUserRole(id, role), Times.Once);
        }

        [Test]
        public void AssignUserRole_InvalidData_ReturnsBadRequestWithErrorMessage()
        {
            // Arrange
            var id = 1;
            var role = "InvalidRole";
            var errorMessage = "Role does not exist.";

            _userRoleServiceMock.Setup(s => s.AssignUserRole(id, role)).Throws(new Exception(errorMessage));

            // Act
            var result = _controller.AssignUserRole(id, role);

            // Assert
            NUnit.Framework.Assert.IsInstanceOf<BadRequestObjectResult>(result);

            var badRequestResult = (BadRequestObjectResult)result;
            NUnit.Framework.Assert.AreEqual(errorMessage, badRequestResult.Value);
        }

        [Test]
        public void DeleteUserRole_ValidData_ReturnsNoContentResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.DeleteUserRole(id); 

            // Assert
            NUnit.Framework.Assert.IsInstanceOf<NoContentResult>(result);
            _userRoleServiceMock.Verify(s => s.RemoveUserRole(id), Times.Once);
        }
    }
}
