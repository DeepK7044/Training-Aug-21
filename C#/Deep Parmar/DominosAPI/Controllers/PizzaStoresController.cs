using DominosAPI.Authentication;
using DominosAPI.DTOs;
using DominosAPI.IRepository;
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
    public class PizzaStoresController : ControllerBase
    {
        private readonly IPizzaStoreRepository _PizzaStore;

        public PizzaStoresController(IPizzaStoreRepository pizzaStoreRepository)
        {
            _PizzaStore = pizzaStoreRepository;
        }

        [HttpGet]
        public IActionResult GetPizzaStores()
        {
            var PizzaStores = _PizzaStore.GetPizzaStores();
            if (PizzaStores == null)
            {
                return NotFound();
            }
            return Ok(PizzaStores);
        }

        [HttpGet("Search")]
        public IActionResult GetAllPizzaStores(int Pincode)
        {
            var PizzaStores = _PizzaStore.GetAllPizzaStore(Pincode);
            if (PizzaStores == null)
            {
                return NotFound();
            }
            return Ok(PizzaStores);
        }

        [HttpGet("{StoreId}")]
        public IActionResult GetPizzaStore(int StoreId)
        {
            var PizzaStore = _PizzaStore.GetPizzaStore(StoreId);
            if (PizzaStore == null)
            {
                return NotFound($"PizzaStore Which id is : {StoreId} Is Not Available");
            }
            return Ok(PizzaStore);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult AddPizzaStore(PizzaStoreDTO Store)
        {
            if (Store == null)
            {
                throw new ArgumentNullException(nameof(Store));
            }
            _PizzaStore.AddPizzaStore(Store);
            return Ok();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{StoreId}")]
        public IActionResult RemovePizzaStore(int StoreId)
        {
            var PizzaStore = _PizzaStore.GetById(StoreId);
            if (PizzaStore == null)
            {
                return NotFound($"PizzaStore Which id is : {StoreId} Is Not Available");                             
            }
            var Result = _PizzaStore.Delete(PizzaStore);
            if (Result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing PizzaStore Failed." });
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{StoreId}")]
        public IActionResult UpdatePizzaStore(int StoreId, PizzaStoreDTO StoreDto)
        {
            if (StoreDto == null)
            {
                throw new ArgumentNullException(nameof(StoreDto));
            }
            var PizzaStoreExists = _PizzaStore.GetById(StoreId);
            if (PizzaStoreExists != null)
            {
                var Result = _PizzaStore.UpdatePizzaStore(StoreId, StoreDto);
                if (Result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "PizzaStore Updation Failed." });
            }
            return NotFound($"PizzaStore Which id is : {StoreId} Is Not Available");
        }
    }
}
