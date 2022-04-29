using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SiteX.Data.Models;
using SiteX.Web.ViewModels;
using SiteX.WebAPI.Settings;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiteX.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyAccountController : ControllerBase
    {
        private readonly IOptions<JwtSettings> jwtSettings;

        private readonly UserManager<ApplicationUser> userManager;

        public MyAccountController(
             IOptions<JwtSettings> jwtSettings
            , UserManager<ApplicationUser> userManager)
        {
            this.jwtSettings = jwtSettings;
            this.userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginInputModel input)
        {
            var user = await userManager.FindByNameAsync(input.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, input.Password))
            {


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this.jwtSettings.Value.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Name, input.Username.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                                     new SymmetricSecurityKey(key),
                                     SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenAsString = tokenHandler.WriteToken(token);
                return Ok(tokenAsString);
            }
            return Unauthorized();
        }
       
    }
}
