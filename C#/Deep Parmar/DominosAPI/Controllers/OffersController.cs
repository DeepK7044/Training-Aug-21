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
    public class OffersController : ControllerBase
    {
        private readonly IOfferRepository Offer;

        public OffersController(IOfferRepository offerRepository)
        {
            Offer = offerRepository;
        }

        [HttpGet]
        public IActionResult GetAllOffers()
        {
            var offers = Offer.GetAllOffers();
            if (offers == null)
            {
                return NotFound();
            }
            return Ok(offers);
        }

        [HttpGet("{OfferId}")]
        public IActionResult GetOffer(int OfferId)
        {
            var offer = Offer.GetOffer(OfferId);
            if (offer == null)
            {
                return NotFound();
            }
            return Ok(offer);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult AddOffer(Offer offer)
        {
            if (offer == null)
            {
                throw new ArgumentNullException(nameof(offer));
            }
            Offer.Add(offer);
            return Ok();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{OfferId}")]
        public IActionResult DeleteOffer(int OfferId)
        {
            var offer = Offer.GetById(OfferId);
            if (offer == null)
            {
                return NotFound($"Offer Which id is : {OfferId} Is Not Available");
            }
            var Result = Offer.Delete(offer);
            if (Result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Removing Offer Failed." });
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{OfferId}")]
        public IActionResult UpdateOffer(int OfferId,Offer offer)
        {
            if (offer==null)
            {
                throw new ArgumentNullException(nameof(offer));
            }
            offer.OfferId = OfferId;
            var result = Offer.UpdateOffer(OfferId,offer);
            if (result)
            {
                return Ok();
            }            
            return BadRequest();
        }
    }
}
