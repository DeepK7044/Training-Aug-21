using DominosAPI.Authentication;
using DominosAPI.IRepository;
using DominosAPI.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class ToppingsController : ControllerBase
    {
        private readonly IToppingRepository _Topping;

        public ToppingsController(IToppingRepository toppingRepository)
        {
            _Topping = toppingRepository;
        }

        [HttpGet]
        public IActionResult GetToppings()
        {
            var toppings = _Topping.GetToppings();
            if (toppings == null)
            {
                return NotFound();
            }
            return Ok(toppings);
        }

        [HttpGet("{ToppingId}")]
        public IActionResult GetTopping(int ToppingId)
        {
            var Topping = _Topping.GetTopping(ToppingId);
            if (Topping == null)
            {
                return NotFound();
            }
            return Ok(Topping);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult AddTopping(Topping  topping)
        {
            if (topping == null)
            {
                throw new ArgumentNullException(nameof(topping));
            }
            _Topping.Add(topping);
            return Ok(new Response { Status = "Success", Message = "topping Created Successfully" });
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{ToppingId}")]
        public IActionResult UpdateTopping(int ToppingId, Topping topping)
        {
            if (topping == null)
            {
                throw new ArgumentNullException(nameof(topping));
            }
            var ToppingExists = _Topping.GetById(ToppingId);
            if (ToppingExists == null)
            {
                return NotFound($"Topping Which id is : {ToppingId} Is Not Available");
            }
            var result = _Topping.UpdateToppings(ToppingId, topping);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{ToppingId}")]
        public IActionResult DeleteTopping(int ToppingId)
        {
            var topping = _Topping.GetById(ToppingId);
            if (topping == null)
            {
                return NotFound($"Topping Which id is : {ToppingId} Is Not Available");
            }
            var Result = _Topping.Delete(topping);
            if (Result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing PizzaStore Failed." });
        }
    }
}
