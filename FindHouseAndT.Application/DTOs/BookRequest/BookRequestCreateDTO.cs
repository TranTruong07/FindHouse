using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.Application.DTOs
{
	public class BookRequestCreateDTO
	{
		public int Id { get; set; }
		public Guid IdCustomer { get; set; }
		public int RoomId { get; set; }
		public string? RoomCode { get; set; }
		[Required]
		public string? FullName { get; set; }
		[Required]
		public DateOnly DateOfBirth { get; set; }
		[Required]
		public string? Address { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public string? UrlFrontCCCD { get; set; }
		public string? UrlBackCCCD { get; set; }
		[Required]
		public IFormFile? ImgFrontCCCD { get; set; }
		[Required]
		public IFormFile? ImgBackCCCD { get; set; }
        [Required]
        public DateOnly StartTimeBook { get; set; }
        [Required]
        public DateOnly EndTimeBook { get; set; }
        public string? Note { get; set; }
		public string? Status {  get; set; }
		public string? UrlRoom { get; set; }
	}
}
