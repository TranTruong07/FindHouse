using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.Entities
{
    public class Motel
    {
        public Guid IdMotel { get; set; }
        public required string Name {  get; set; }
        public required string Address {  get; set; }
        public required int QuantityRoom { get; set; }
        public required Guid IdHouseOwner { get; set; }
        public HouseOwner? HouseOwner { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
