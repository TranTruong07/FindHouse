using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.DTOs
{
	public class CreateContractDTO
	{
		[Required]
		public Guid IdCustomer { get; set; }
		[Required]
		public int IdRoom { get; set; }
		[Required]
		public int BookRequestId { get; set; }
		[Required]
		public string FullNameHouseOwner { get; set; }
		[Required]
		public string FullNameCustomer { get; set; }
		[Required]
		public string PhoneHouseOwner { get; set; }
		[Required]
		public  string PhoneCustomer { get; set; }
		[Required]
		public DateOnly StartDate { get; set; }
		[Required]
		public DateOnly EndDate { get; set; }
		[Required]
		public DateOnly BookDate { get; set; }
		[Required]
		public decimal Price { get; set; }
		public string TermsOfContract { get; set; }
		public Room? Room { get; set; }
	}
}
