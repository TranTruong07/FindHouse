using FindHouseAndT.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.Entities
{
    public class Order
    {
        public Guid IdOrder { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid IdHouseOwner { get; set; }
        public Guid IdMotel { get; set; }
        public required string IdRoom { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public Customer? Customer { get; set; }
        public HouseOwner? HouseOwner { get; set; }
        public Motel? Motel { get; set; }
        public Room? Room { get; set; }
    }
}
