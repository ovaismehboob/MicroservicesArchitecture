using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Models
{
    public class UserEntity : IdentityUser<Guid>
    {

        public int VendorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        
    }
}
