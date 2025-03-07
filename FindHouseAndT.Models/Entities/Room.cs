﻿
namespace FindHouseAndT.Models.Entities
{
    public class Room
    {
        public int ID { get; set; }
        public required string RoomCode { get; set; }
        public int Floor {  get; set; }
        public double Area { get; set; }
        public decimal Price { get; set; }
        public required string Status { get; set; }
        public required string Description1 { get; set; }
        public string? Description2 { get; set; }
		public required string KeyImageRoom { get; set; }
		public Guid IdMotel { get; set; }
        public Motel? Motel { get; set; }
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public ICollection<BookRequest> BookRequests { get; set; } = new List<BookRequest>();
    }
}
