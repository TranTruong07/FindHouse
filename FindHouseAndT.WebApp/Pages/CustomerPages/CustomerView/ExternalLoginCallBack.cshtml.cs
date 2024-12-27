using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FindHouseAndT.WebApp.Pages.CustomerPages
{
	public class ExternalLoginCallBackModel : PageModel
	{
		private readonly SignInManager<UserApp> _signInManager;
		private readonly UserManager<UserApp> _userManager;
		private readonly CustomerService _customerService;

		public ExternalLoginCallBackModel(SignInManager<UserApp> signInManager, UserManager<UserApp> userManager, CustomerService customerService)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_customerService = customerService;
		}

		public async Task<IActionResult> OnGetAsync(string returnUrl, string remoteError)
		{
			var infor = await _signInManager.GetExternalLoginInfoAsync();
			if (infor == null)
			{
				return RedirectToPage("/CustomerPages/CustomerView/UserManager");
			}
			var signInResult = await _signInManager.ExternalLoginSignInAsync(infor.LoginProvider, infor.ProviderKey, isPersistent: false);
			if (signInResult.Succeeded)
			{
				return RedirectToPage("/Index");
			}
			else
			{
				var email = infor.Principal.FindFirstValue(ClaimTypes.Email);
				if (email == null)
				{
					return RedirectToPage("/CustomerPages/CustomerView/UserManager");
				}
				var getUser = await _userManager.FindByEmailAsync(email);
				if (getUser != null)
				{
					await _userManager.AddLoginAsync(getUser, infor);
					await _signInManager.SignInAsync(getUser, isPersistent: false);
					return RedirectToPage("/Index");
				}
				var user = new UserApp()
				{
					UserName = email,
					Email = email,
					EmailConfirmed = true
				};
				var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
					var addLoginResult = await _userManager.AddLoginAsync(user, infor);
					var customer = new Customer() {IdUser = user.Id, Name = user.Email };
					var addCustomerResult = await _customerService.Register(customer);
					var addToRoleResult = await _userManager.AddToRoleAsync(user, UserRole.Customer);
					if (addLoginResult.Succeeded && addCustomerResult && addToRoleResult.Succeeded)
					{
						await _signInManager.SignInAsync(user, isPersistent: false);
						return RedirectToPage("/Index");
					}
                }
				return RedirectToPage("/CustomerPages/CustomerView/UserManager");
			}
		}
	}
}
