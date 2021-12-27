using DominosAPI.Authentication;
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
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemRepository _cartItem;
        private readonly IUserRepository _user;

        public CartItemsController(ICartItemRepository cartItem,IUserRepository user)
        {
            _cartItem = cartItem;
            _user = user;
        }

        [HttpGet]
        [Route("~/api/Users/{UserId}/CartItems")]
        public IActionResult GetCartItems(int UserId)
        {
            var user = _user.GetById(UserId);
            if (user==null)
            {
                return NotFound($"User Which id is : {UserId} Is Not Available");
            }
            var CartItems = _cartItem.GetCartItems(UserId);
            if (CartItems == null)
            {
                return NotFound($"CartItems Is Not Available for User Which id is:{UserId}");
            }
            return Ok(CartItems);
        }

        [HttpPost]
        [Route("~/api/Users/{UserId}/CartItems")]
        public IActionResult AddCartItems(Cart[] CartItems,int UserId)
        {
            var user = _user.GetById(UserId);
            if (user == null)
            {
                return NotFound($"User Which id is : {UserId} Is Not Available");
            }
            if (CartItems == null)
            {
                throw new ArgumentNullException(nameof(CartItems));
            }
            _cartItem.AddCartItems(CartItems,UserId);
            return Ok(new Response { Status = "Success", Message = "CartItems Added Successfully" });
        }

        [HttpDelete("{CartId}")]
        public IActionResult DeleteCategory(int CartId)
        {
            var CartItem = _cartItem.GetById(CartId);
            if (CartItem == null)
            {
                return NotFound($"CartItem Which id is : {CartId} Is Not Available");
            }
            var Result = _cartItem.Delete(CartItem);
            if (Result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing CartItem Failed." });
        }
    }
}
