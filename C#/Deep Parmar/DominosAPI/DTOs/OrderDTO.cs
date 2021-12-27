using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int DeliveryEmpId { get; set; }
        public bool OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public int AddressId { get; set; }
        public ICollection<OrderPizzaDTO> Pizza { get; set; }
    }
}
