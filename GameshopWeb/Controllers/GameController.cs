using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GameshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public GameController(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }

        [HttpGet("genres")]
        public List<Genre> GetGenres()
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                return conn.Query<Genre>("SELECT * FROM Genre").ToList();
            }
        }

        [HttpGet("companies")]
        public List<Company> GetCompanies()
        {
            using(var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                return conn.Query<Company>("SELECT * FROM Company").ToList();
            }
        }

        [HttpGet("bygenre/{id}")]
        public List<Game> GetByGenre(int id)
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                return conn.Query<Game>("SELECT * FROM Game WHERE idGenre = @id", new { id }).ToList();
            }
        }

        [HttpGet("bycompany/{id}")]
        public List<Game> GetByCompany(int id)
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                return conn.Query<Game>("SELECT * FROM Game WHERE idPublisher = @id OR idDeveloper = @id", new { id }).ToList();
            }
        }

        [HttpGet("search/{text}")]
        public List<Game> Search(string text)
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                string textParam = $"%{text}%";
                return conn.Query<Game>(
                    @"SELECT * FROM Game
                      WHERE Title LIKE @textParam", new
                    {
                        textParam
                    }).ToList();
            }
        }
    }
}
