using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DominosAPI.DTOs
{
    public class ContactUsDTO
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
