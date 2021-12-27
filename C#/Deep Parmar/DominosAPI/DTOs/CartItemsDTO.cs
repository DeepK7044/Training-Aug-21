using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class CartItemsDTO
    {
        public int CartId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "PizzaId is required")]
        public int PizzaId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public byte Quantity { get; set; }
    }
}
