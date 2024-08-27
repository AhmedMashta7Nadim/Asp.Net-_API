using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models.VM.Authenticate;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthenticateController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("Authentication")]
        public ActionResult<string> Authentication([FromBody] AuthRequest request)
        {
            var user = ValidateUserInformation(request.UserName, request.Password);
         

            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:Key"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>() {
            new Claim("name",configuration["User:username"]),
            };

            var securityToken = new JwtSecurityToken
            (
                issuer: configuration["Authentication:Issur"],
                audience: configuration["Authentication:Audience"],
                    claims,
                 DateTime.UtcNow,
                 DateTime.UtcNow.AddHours(10),
                signingCredentials
            );
                if(request.UserName== configuration["User:username"]
                && request.Password== configuration["User:password"])
                {
                 var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
                  return Ok(token);
                }
            return Unauthorized("user name or passwird error"); 
        }

        private User ValidateUserInformation(string userName, string password)
        {
            var configUserName = configuration["User:username"];
            var configPassword = configuration["User:password"];
           
                Console.WriteLine(configUserName);
                Console.WriteLine("aaaaaaaaaaaasdddddddddddddddddddd \n \n \n \n \n \n \n \n \n ");
                return new User
                {

                    FirstName = "Ahmed",
                    LastName = "Ndaim",
                    username = userName,
                    Id = 7
                };
           
        }
    }
}
