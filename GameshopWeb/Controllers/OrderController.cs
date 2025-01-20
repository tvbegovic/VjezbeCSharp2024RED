using Dapper;
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
    }
}
