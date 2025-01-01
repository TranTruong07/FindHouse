using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.Entities
{
    public class HouseOwner
    {
        public Guid IdHouseOwner { get; set; }
        public required string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public UserApp? UserApp { get; set; }
        public ICollection<Motel> Motels { get; set; } = new List<Motel>();
    }
}
