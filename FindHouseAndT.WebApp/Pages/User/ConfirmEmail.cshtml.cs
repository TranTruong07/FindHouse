using FindHouseAndT.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.User
{
	public class ConfirmEmailModel : PageModel
	{
		private UserManager<UserApp> _userManager;

		public ConfirmEmailModel(UserManager<UserApp> userManager)
		{
			_userManager = userManager;
		}

		public bool IsEmailConfirmed { get; set; }
		public async Task<IActionResult> OnGetAsync(string userId, string code)
		{
			if (userId != null && code != null)
			{
				var user = await _userManager.FindByIdAsync(userId);
				if (user == null)
				{
					return NotFound($"Not found User {userId}");
				}
				var result = await _userManager.ConfirmEmailAsync(user, code);
				if (result.Succeeded)
				{
					IsEmailConfirmed = true;
				}
			}
			return Page();
		}
	}
}
