using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.DTOs
{
    public class BookRequestShowListDTO
    {
        public int Id { get; set; }
        public Guid IdCustomer { get; set; }
        public string? FullName { get; set; }
        public string? RoomCode { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string? UrlFrontCCCD { get; set; }
        public string? UrlBackCCCD { get; set; }
		public DateOnly StartTimeBook { get; set; }
		public DateOnly EndTimeBook { get; set; }
		public string Status {  get; set; }
        public string? Note { get; set; }
    }
}
