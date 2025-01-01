using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Models.Entities
{
    public class Customer
    {
        public Guid IdUser { get; set; }
        public required string Name { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? Avatar {  get; set; }
        public UserApp? UserApp { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<BookRequest> BookRequests { get; set; } = new List<BookRequest>();
    }
}
