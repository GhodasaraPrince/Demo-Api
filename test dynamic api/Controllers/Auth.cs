using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using test_dynamic_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace test_dynamic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        public readonly DataContext _context;
        public readonly IConfiguration _config;
        public Auth(DataContext context , IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Registration model)
        {

            var tempdata = _context.Registration.FirstOrDefault(x => x.userName == model.userName);
            if (tempdata != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse { Status = "Error", Message = "User already exists!" });

            if(model.firstName == "")
            {
                return Ok(new ApiResponse { Status = "Failer", Message = "Username is not valid" });
            }
            else
            {
                var result = _context.Registration.Add(model);
                await _context.SaveChangesAsync();
                return Ok(new ApiResponse { Status = "Success", Message = "User created successfully!" });
            }
            //if (result.State == "Added")
            //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        } 

        [HttpPost]
        [Route("Login")]
        public async Task<string> Login([FromBody] LoginModel req)
        {
            var userData = await _context.Registration.ToListAsync();
            List<Registration> flag =  _context.Registration.Select(x => x).
                Where(x => x.userName == req.userName && x.password == req.password).ToList();
            if (flag.Any())
            {
                string token = CreateToken(req , flag[0]);
                return token;
            }
            return "Invalid Login";
        }

        private string CreateToken(LoginModel req , Registration userData)
        {
            
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , req.userName),
                new Claim("FirstName" , userData.firstName),
                new Claim("LastName", userData.lastName),
                new Claim(ClaimTypes.Email , userData.email),
                new Claim("Number", userData.number),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("JWT:Secret").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
