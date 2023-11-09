using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using webapi.Data;
using webapi.Data.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenAuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public TokenAuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _config = configuration;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLogin)
        {
            var user = await _userManager.FindByNameAsync(userLogin.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userLogin.Password))
            {
                return Unauthorized();
            }
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //var roles = await _userManager.GetRolesAsync(user);
            //if (roles.Count != 0)
            //{
            //    foreach (var role in roles)
            //    {
            //        authClaims.Add(new Claim(ClaimTypes.Role, role));
            //    }

            //}
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var tokenDiscriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDiscriptor);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                expires = token.ValidTo
            });

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegister)
        {
            if (userRegister == null)
            {
                throw new ArgumentNullException(nameof(userRegister));
            }
            var user = new User
            {
                Email = userRegister.Email,
                PhoneNumber = userRegister.PhoneNumber,
                UserName=userRegister.UserName
            };
            var resutl = await _userManager.CreateAsync(user, userRegister.Password);
           
            
            if(resutl.Succeeded)
            {
                return Ok();

            }

            return Unauthorized(resutl);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("data")]
        public IActionResult Data()
        {
            var user = User.Identity as ClaimsIdentity;
            var claims = new Dictionary<string, string>();
            foreach (var claim in user?.Claims ?? Array.Empty<Claim>())
            {
                claims.Add(claim.Type, claim.Value);
            }
            return Ok(claims);

        }

    }
}
