using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.WebApp.DTOs.BookRequest
{
	public class BookRequestDTO
	{
		public Guid IdCustomer { get; set; }
		public string RoomCode { get; set; }
		[Required]
		public string FullName { get; set; }
		[Required]
		public DateOnly DateOfBirth { get; set; }
		[Required]
		public string Address { get; set; }
		public string? UrlFrontCCCD { get; set; }
		public string? UrlBackCCCD { get; set; }
		[Required]
		public IFormFile ImgFrontCCCD { get; set; }
		[Required]
		public IFormFile ImgBackCCCD { get; set; }
		public string? Note { get; set; }
	}
}
