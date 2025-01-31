using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace OnlineshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public OrderController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet("forClient/{id}")]
        public List<Order> GetOrdersForClient(int id)
        {
            string orderSql = "SELECT * FROM [Order] WHERE idClient = @id";
            string detailsSql = "SELECT * FROM OrderDetail WHERE idOrder = @id";
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                List<Order> orders = conn.Query<Order>(orderSql, new { id }).ToList();
                foreach (var order in orders)
                {
                    order.Details = conn.Query<OrderDetail>(detailsSql, new { id = order.Id }).ToList();    
                }
                return orders;
            }
        }
    }
}
