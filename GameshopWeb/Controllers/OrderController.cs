using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GameshopWeb.Controllers
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

        [HttpPost("")]
        public void CreateOrder(Order order)
        {
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                string sqlOrder = @"INSERT INTO Order(
                idUser,idEmployee,dateOrdered,dateSent
                ) OUTPUT inserted.id VALUES(
                @idUser,@idEmployee,@dateOrdered,@dateSent
                )";
                order.DateOrdered = DateTime.Now;
                order.Id = conn.ExecuteScalar<int>(sqlOrder, order);
                foreach (OrderDetail detail in order.Details)
                {
                    string sqlDetail = @"INSERT INTO OrderDetail(
                    idOrder,idGame,quantity,unitprice
                    ) OUTPUT inserted.id VALUES(
                    @idOrder,@idGame,@quantity,@unitprice
                    )
                     ";
                    detail.IdOrder = order.Id;
                    conn.Execute(sqlDetail, detail);
                }
            }
        }

        [HttpGet("forUser/{idUser}")]
        [Authorize]
        public List<Order> GetOrdersForUser(int idUser)
        {
            string sqlOrders = "SELECT * FROM [Order] WHERE idUser = @idUser";
            using (var conn = new SqlConnection(configuration.GetConnectionString("connString")))
            {
                List<Order> orders = conn.Query<Order>(sqlOrders, new { idUser }).ToList();
                foreach (var order in orders)
                {
                    string sqlDetails = "SELECT * FROM OrderDetail WHERE idOrder = @id";
                    order.Details = conn.Query<OrderDetail>(sqlDetails, new { id = order.Id }).ToList();
                }
                return orders;
            }
        }
    }
}
