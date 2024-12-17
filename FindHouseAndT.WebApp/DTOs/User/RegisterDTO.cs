using FindHouseAndT.WebApp.ValidationAttributeCustom;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FindHouseAndT.WebApp.DTOs.User
{
    public class RegisterDTO
    {
        [Required]
        public string FullName { get; set; }
		[Required]
		[EmailAddress]
        public string Email { get; set; }
		[Required]
		[MinimumAge(18, ErrorMessage ="User need 18")]
        public DateOnly BirthDate { get; set; }
		[Required]
		public  string Password { get; set; }
		[Required]
		[ComparePassword(nameof(Password), ErrorMessage ="confirm pass invalid.")]
        public string ConfirmPassword { get; set; }
        
    }
}
