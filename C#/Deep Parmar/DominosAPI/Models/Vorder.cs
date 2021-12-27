using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class Vorder
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int DeliveryEmpId { get; set; }
        public int AddressId { get; set; }
        public string PizzaId { get; set; }
        public string PizzaName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public bool OrderStatus { get; set; }
    }
}
