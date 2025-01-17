using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GameshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
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
    }
}
