using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.Application.DTOs
{
    public class ProfileCustomerDTO
    {
        [Required]
        public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public DateOnly? BirthDate { get; set; }
		public string? UrlAvatar { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
