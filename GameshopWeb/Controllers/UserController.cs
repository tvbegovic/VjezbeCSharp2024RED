using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameshopWeb.Controllers
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

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(user.Password.Length < 8)
            {
                return BadRequest("Lozinka moram imati najmanje 8 znakova");
            }
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                var sql = "SELECT COUNT(*) FROM [User] WHERE email = @email";
                var broj = conn.ExecuteScalar<int>(sql, new
                {
                    email = user.Email,
                });
                if(broj > 0)
                {
                    return BadRequest("Već postoji korisnik s tom email adresom");
                }
                string insertSQL = @"INSERT INTO [User](
                    firstname,lastname,address,email,password,admin,City
                    ) OUTPUT inserted.id VALUES(
                    @firstname,@lastname,@address,@email,@password,@admin,@City
                    )";
                conn.Execute(insertSQL, user);
                return Ok();
            }
        }

        [HttpGet("login")]
        public IActionResult Login(string email, string password)
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                var user = conn.QueryFirstOrDefault<User>(
                    "SELECT * FROM [User] WHERE email = @email AND password = @password", new {  email, password });
                if (user == null)
                {
                    return BadRequest("Pogrešni email ili lozinka");
                }
                LoginResult result = new LoginResult();
                result.User = user;
                result.User.Password = null;
                result.AccessToken = GenerateToken(email, "User");
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

        [HttpPut("")]
        [Authorize]
        public void UpdateUser([FromBody] User user)
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                string sql = @"UPDATE [User] SET 
firstname=@firstname,lastname=@lastname,address=@address,admin=@admin,City=@City
WHERE id = @id";
                conn.Execute(sql, user);
            }
        }
    }



    public class LoginResult
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
    }
}
