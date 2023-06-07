using Infrastructure.EF.Entities;
using Infrastructure.Mappers;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Configuration;
using WebAPI.Dto;
using WebAPI;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<UsersEntity> _manager;
        private readonly JwtSettings _jwtSettings;



        public AuthenticationController(UserManager<UsersEntity> manager, JwtSettings jwtSettings)
        {
            _manager = manager;
            _jwtSettings = jwtSettings;
        }



        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized();
            }

            var logged = await _manager.FindByNameAsync(user.Username);
            if (logged == null || !await _manager.CheckPasswordAsync(logged, user.Password))
            {
                return Unauthorized();
            }

            var token = CreateToken(logged);
            return Ok(new { Token = token });
        }



        [HttpPost("register/user")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            
            var user = Mappers.UsersMapper.FromDtoToUserEntity(userDto);

            var result = await _manager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _manager.AddToRoleAsync(user, "User");

            return Ok();
        }



        private string CreateToken(UsersEntity user)
        {
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
                .AddClaim(JwtRegisteredClaimNames.Name, user.UserName)
                .AddClaim(JwtRegisteredClaimNames.Gender, "male")
                .AddClaim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
                .AddClaim(JwtRegisteredClaimNames.Email, user.Email)
                .AddClaim(JwtRegisteredClaimNames.Exp, DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds())
                .AddClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                .Audience(_jwtSettings.Audience)
                .Issuer(_jwtSettings.Issuer)
                .Encode();
        }



        [HttpPost("register/admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin(UserRegisterDto userDto)
        {
            var user = Mappers.UsersMapper.FromDtoToUserEntity(userDto);

            var result = await _manager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _manager.AddToRoleAsync(user, "Admin");

            return Ok();
        }






    }
}
