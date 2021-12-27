using System;
using System.Collections.Generic;

#nullable disable

namespace DominosAPI.Models
{
    public partial class ContactU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Message { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
