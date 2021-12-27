using DominosAPI.Authentication;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _Order;
        private readonly IUserRepository _User;

        public OrdersController(IOrderRepository order,IUserRepository userRepository)
        {
            _Order = order;
            _User = userRepository;
        }

        [HttpGet]
        [Route("~/api/Users/{UserId}/Orders")]
        public IActionResult GetOrder(int UserId)
        {
            var user=_User.GetById(UserId);
            if (user==null)
            {
                return NotFound($"User Which id is : {UserId} Is Not Available");
            }
            var Orders=_Order.GetOrder(UserId);
            if (Orders==null)
            {
                return NotFound();
            }
            return Ok(Orders);
        }

        [HttpGet]
        [Route("~/api/Users/{UserId}/Orders/{OrderId}/OrderDetails")]
        public IActionResult GetOrderDetails(int UserId,int OrderId)
        {
            var user = _User.GetById(UserId);
            if (user == null)
            {
                return NotFound($"User Which id is : {UserId} Is Not Available");
            }
            var order = _Order.GetById(OrderId);
            if (order == null)
            {
                return NotFound($"Order Which id is : {OrderId} Is Not Available");
            }
            var OrderDetails = _Order.GetOrderDetails(OrderId);
            if (OrderDetails == null)
            {
                return NotFound();
            }
            return Ok(OrderDetails);
        }


        [HttpPost]
        public IActionResult AddOrder(OrderDTO order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _Order.AddOrder(order);
            return Ok(new Response { Status = "Success", Message = "Order Created Successfully" });
        }

        [HttpDelete("{OrderId}")]
        public IActionResult DeleteCategory(int OrderId)
        {
            var Order = _Order.GetById(OrderId);
            if (Order == null)
            {
                return NotFound($"Order Which id is : {OrderId} Is Not Available");
            }
            var Result = _Order.Delete(Order);
            if (Result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing Order Failed." });
        }
    }
}
