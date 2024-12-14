using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.Entities
{
    public class UserApp : IdentityUser<Guid>
    {
        public Customer? Customer { get; set; }
        public HouseOwner? HouseOwner { get; set; }
    }
}
