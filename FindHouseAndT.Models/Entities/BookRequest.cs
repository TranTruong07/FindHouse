using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.Entities
{
    public class BookRequest
    {
        public int Id { get; set; }
        public required Guid IdCustomer { get; set; }
        public required int RoomId { get; set; }
		public required string FullName { get; set; }
		public required DateOnly DateOfBirth { get; set; }
		public required string Address { get; set; }
        public required string KeyUrlFrontCCCD { get; set; }
        public required string KeyUrlBackCCCD { get; set; }
        public string? Note {  get; set; }
        public required string Status { get; set; }
        public Customer? Customer { get; set; }
        public Room? Room { get; set; }

    }
}
