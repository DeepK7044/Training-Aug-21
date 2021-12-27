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
    public class PincodesController : ControllerBase
    {
        private readonly IPincodeRepository _pincode;

        public PincodesController(IPincodeRepository pincode)
        {
            _pincode = pincode;
        }

        [HttpGet]
        public IActionResult GetPincodes()
        {
            var Pincodes = _pincode.GetPincodes();
            if (Pincodes==null)
            {
                return NotFound("Pincode is Not Available");
            }
            return Ok(Pincodes);
        }

        [HttpGet("{Pincode}")]
        public IActionResult GetPincodes(int Pincode)
        {
            var pincode = _pincode.GetPincode(Pincode);
            if (pincode == null)
            {
                return NotFound("Pincode is Not Available");
            }
            return Ok(pincode);
        }

        [HttpPost]
        public IActionResult AddPincode(Pincode pincode)
        {
            if (pincode==null)
            {
                throw new ArgumentNullException(nameof(pincode));
            }
            var Pincode = _pincode.GetById(pincode.Pincode1);
            if (Pincode != null)
            {
                return NotFound("Pincode is Already Available");
            }
            var result = _pincode.AddPincode(pincode);
            if (result)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Adding Pincode Failed." });
        }
    }
}
