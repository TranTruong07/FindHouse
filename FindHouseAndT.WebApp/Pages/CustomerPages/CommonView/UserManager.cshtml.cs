using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using FindHouseAndT.Models.MailKit;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FindHouseAndT.Application.ExternalInterface;

namespace FindHouseAndT.WebApp.Pages.CustomerPages
{
	public class UserManagerModel : PageModel
	{
		[BindProperty]
		public RegisterDTO RegisterDTO { get; set; } = new RegisterDTO();
		[BindProperty]
		public LoginDTO LoginDTO { get; set; } = new LoginDTO();
		private readonly UserManager<UserApp> _userManager;
		private readonly ICustomerService _customerService;
		private readonly IEmailService _mailService;
		private readonly SignInManager<UserApp> _signInManager;
		public UserManagerModel(UserManager<UserApp> userManager, ICustomerService customerService, IEmailService mailService, SignInManager<UserApp> signInManager)
		{
			_userManager = userManager;
			_customerService = customerService;
			_mailService = mailService;
			_signInManager = signInManager;
		}

		public async Task OnGetAsync()
		{
			LoginDTO.Schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
		}

		public async Task<IActionResult> OnPostRegisterAsync()
		{
			ModelState.Clear();

			if (TryValidateModel(RegisterDTO, nameof(RegisterDTO)))
			{
				var result1 = await _userManager.FindByEmailAsync(RegisterDTO.Email);
				if (result1 != null)
				{
					ModelState.AddModelError("Email", "Email is exist.");
				}
				else
				{
					var user = new UserApp()
					{
						UserName = RegisterDTO.Email,
						Email = RegisterDTO.Email,
						EmailConfirmed = false
					};
					var custom = new Customer()
					{
						Name = RegisterDTO.FullName,
						BirthDate = RegisterDTO.BirthDate,
					};
					var result2 = await _userManager.CreateAsync(user, RegisterDTO.Password);
					if (result2.Succeeded)
					{
						var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
						var callbackUrl = Url.Page(
                            "/CustomerPages/CustomerView/ConfirmEmail",
							pageHandler: null,
							values: new { userId = user.Id, code = code },
							protocol: Request.Scheme);
						var mailContent = new MailContent() { Email = user.Email, Content = $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.", Subject = "Welcome" };
						var result = await _mailService.SendMailAsync(mailContent);
						await _userManager.AddToRoleAsync(user, UserRole.Customer);
						custom.IdUser = user.Id;
						var result3 = await _customerService.Register(custom);
						if (result3.ResultCode == ResultCode.Success)
						{
							return Redirect("/CustomerPages/CommonView/Index");
						}
					}
				}
			}
			return Page();

		}

		public async Task<IActionResult> OnPostLoginAsync()
		{
			ModelState.Clear();

			if (TryValidateModel(LoginDTO, nameof(LoginDTO)))
			{
				var user = await _userManager.FindByEmailAsync(LoginDTO.Email);
                if (user == null)
                {
					ModelState.AddModelError("Not found", "Not found User");
					return NotFound("Not found user.");
				}
				else
				{
					if (!await _userManager.CheckPasswordAsync(user, LoginDTO.Password))
					{
						ModelState.AddModelError("Error", "Error Password");
					}
					else
					{
						if(!await _userManager.IsEmailConfirmedAsync(user))
						{
							return RedirectToPage("/CustomerPages/CustomerView/ConfirmEmail");
						}
						await _signInManager.SignInAsync(user, isPersistent: false);
						return RedirectToPage("/CustomerPages/CommonView/Index");
					}
				}
				
            }
			LoginDTO.Schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
			return Page();
		}
		[BindProperty]
		public string Provider {  get; set; } = string.Empty;
		public IActionResult OnPostExternalLogin()
		{
			if(Provider == null)
			{
				return Page();
			}
			var redirect = Url.Page("/CustomerPages/CustomerView/ExternalLoginCallBack");
			var property = _signInManager.ConfigureExternalAuthenticationProperties(Provider, redirect);
			return new ChallengeResult(Provider, property);
		}
		public async Task<IActionResult> OnGetSignOutAsync()
		{
			LoginDTO.Schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
			await _signInManager.SignOutAsync();
			return RedirectToPage("/CustomerPages/CommonView/UserManager");
		}
	}
}
