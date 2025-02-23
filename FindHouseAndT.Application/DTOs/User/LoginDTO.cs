using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.Application.DTOs
{
	public class LoginDTO
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		public IEnumerable<AuthenticationScheme>? Schemes { get; set; }
	}
}
