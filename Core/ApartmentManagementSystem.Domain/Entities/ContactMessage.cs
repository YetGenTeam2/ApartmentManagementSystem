using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Domain.Entities
{
    public class ContactMessage
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
