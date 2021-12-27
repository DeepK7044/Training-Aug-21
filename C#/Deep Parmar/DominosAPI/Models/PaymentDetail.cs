using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class PaymentDetail
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string CvvNumber { get; set; }
        public string CardName { get; set; }
        public string UpiId { get; set; }
        public string PaytmNumber { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
