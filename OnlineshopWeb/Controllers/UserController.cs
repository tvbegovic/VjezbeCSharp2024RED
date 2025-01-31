using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly JWTTokenConfig _jwtTokenConfig;

        public UserController(IConfiguration configuration, JWTTokenConfig jWTTokenConfig)
        {
            this.configuration = configuration;
            this._jwtTokenConfig = jWTTokenConfig;
        }

        [HttpGet("login")]
        public IActionResult Login(string username, string password)
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                string sql = "SELECT * FROM Employee WHERE (username = @username OR email = @username) AND password = @password";
                var user = conn.QueryFirstOrDefault<Employee>(sql, new { username, password});
                if(user == null)
                {
                    return BadRequest("Pogrešni korisnički podaci");
                }
                LoginResult result = new LoginResult();
                result.Employee = user;
                result.Employee.Password = null;
                result.AccessToken = GenerateToken(username, password);
                return Ok(result);
            }
        }

        private string GenerateToken(string email, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.UTF8.GetBytes(_jwtTokenConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, email),
            new Claim(ClaimTypes.Role, role)
        }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
                Issuer = _jwtTokenConfig.Issuer,
                Audience = _jwtTokenConfig.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginResult
    {
        public Employee Employee { get; set; }
        public string AccessToken { get; set; }
    }
}
