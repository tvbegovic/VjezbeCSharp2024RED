using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace OnlineshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet("")]
        public List<Product> GetProducts()
        {
            string sql = @"SELECT Product.*, Manufacturer.Name Manufacturer, Category.name Category FROM Product INNER JOIN Manufacturer ON Product.IdManufacturer = Manufacturer.id INNER JOIN Category ON Product.IdCategory = Category.id";
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                return conn.Query<Product>(sql).ToList();
            }
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            string sql = "SELECT * FROM Product WHERE id = @id";
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                return conn.QueryFirstOrDefault<Product>(sql, new { id });
            }
        }

        [HttpPost("")]
        [Authorize]
        public void CreateProduct(Product product)
        {
            string sql = @"INSERT INTO Product(
            Name,Code,Price,IdManufacturer,IdCategory
            ) OUTPUT inserted.id VALUES(
            @Name,@Code,@Price,@IdManufacturer,@IdCategory
            )";
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                conn.Execute(sql, product);
            }
        }

        [HttpPut("")]
        [Authorize]
        public void UpdateProduct(Product product)
        {
            string sql = @"UPDATE Product SET            Name=@Name,Code=@Code,Price=@Price,IdManufacturer=@IdManufacturer,IdCategory=@IdCategory
            WHERE id = @id";
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                conn.Execute(sql, product);
            }

        }

        [HttpGet("search")]
        public List<Product> Search(string name, double? priceFrom, double? priceTo)
        {
            string sql = @"SELECT * FROM Product
            WHERE 
            (Name LIKE @name OR @name IS NULL) AND
            (Price >= @pricefrom OR @pricefrom IS NULL) AND
            (Price <= @priceTo OR @priceTo IS NULL)";
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                string nameParam = $"%{name}%";
                return conn.Query<Product>(sql, new { name = nameParam, priceFrom, priceTo }).ToList();
            }
        }
    }
}
