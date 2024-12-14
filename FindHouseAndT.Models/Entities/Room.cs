using FindHouseAndT.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.Entities
{
    public class Room
    {
        public Guid IdRoom { get; set; }
        public int Floor {  get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public RoomStatus Status { get; set; }
        public Guid IdMotel { get; set; }
        public Motel? Motel { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
