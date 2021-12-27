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
    public class PizzasController : ControllerBase
    {
        private readonly IPizzaRepository Pizza;

        public PizzasController(IPizzaRepository pizzaRepository)
        {
            Pizza = pizzaRepository;
        }

        [HttpGet]
        public IActionResult GetAllPizzas()
        {
            var Pizzas = Pizza.GetAllPizzas();
            if (Pizza==null)
            {
                return NotFound();
            }
            return Ok(Pizzas);
        }

        [HttpGet("{PizzaId}")]
        public IActionResult GetPizza(int PizzaId)
        {
            var pizza = Pizza.GetPizza(PizzaId);
            if (Pizza==null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        [HttpGet("Search")]
        public IActionResult GetPizzas(string PizzaName)
        {
            if(PizzaName==null)
            {
                throw new ArgumentNullException(nameof(PizzaName));
            }

            var Pizzas= Pizza.GetPizzas(PizzaName);
            if (Pizzas!=null)
            {
                return Ok(Pizzas);
            }
            return NotFound();
        }

        [HttpGet("~/api/Categories/{CategoryId}/Pizzas")]
        public IActionResult GetPizzasByCategoriesId(int CategoryId)
        {
            var pizzas = Pizza.GetPizzasByCategoryId(CategoryId);
            if (pizzas == null)
            {
                return NotFound();
            }
            return Ok(pizzas);
        }

        [HttpGet("~/api/Categories/{CategoryId}/Pizzas/{PizzaId}")]
        public IActionResult GetPizzaByCategoriesId(int CategoryId, int PizzaId)
        {
            var pizza = Pizza.GetPizzaByCategoryId(CategoryId,PizzaId);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult AddPizza(Pizza pizza)
        {
            if (Pizza==null)
            {
                throw new ArgumentNullException(nameof(pizza));
            }
            Pizza.Add(pizza);           
            return Ok();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{PizzaId}")]
        public IActionResult DeletePizza(int PizzaId)
        {
            var pizza = Pizza.GetById(PizzaId);
            if (pizza == null)
            {
                return NotFound($"pizza Which id is : {PizzaId} Is Not Available");
            }
            var Result = Pizza.Delete(pizza);
            if (Result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing pizza Failed." });
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{PizzaId}")]
        public IActionResult UpdatePizza(int PizzaId, Pizza pizza)
        {
            if (pizza==null)
            {
                throw new ArgumentNullException(nameof(pizza));
            }
            var pizzaExists = Pizza.GetById(PizzaId);
            if (pizzaExists == null)
            {
                return NotFound($"pizza Which id is : {PizzaId} Is Not Available");
            }
            var result=Pizza.UpdatePizza(PizzaId,pizza);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}
