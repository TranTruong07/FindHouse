using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using FindHouseAndT.Models.MailKit;
using FindHouseAndT.WebApp.DTOs.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages
{
	public class RegisterUserModel : PageModel
	{
		[BindProperty]
		public RegisterDTO RegisterDTO { get; set; } = new RegisterDTO();
		[BindProperty]
		public LoginDTO LoginDTO { get; set; } = new LoginDTO();
		private readonly UserManager<UserApp> _userManager;
		private readonly CustomerService _customerService;
		private readonly IMailService _mailService;
		private readonly SignInManager<UserApp> _signInManager;
		public RegisterUserModel(UserManager<UserApp> userManager, CustomerService customerService, IMailService mailService, SignInManager<UserApp> signInManager)
		{
			_userManager = userManager;
			_customerService = customerService;
			_mailService = mailService;
			_signInManager = signInManager;
		}

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostRegisterAsync()
		{
			if (ModelState.IsValid)
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
						BirthDate = RegisterDTO.BirthDate.ToDateTime(TimeOnly.MinValue),
					};
					var result2 = await _userManager.CreateAsync(user, RegisterDTO.Password);
					if (result2.Succeeded)
					{
						var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
						var callbackUrl = Url.Page(
							"/User/ConfirmEmail",
							pageHandler: null,
							values: new { userId = user.Id, code = code },
							protocol: Request.Scheme);
						var mailContent = new MailContent() { Email = user.Email, Content = $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.", Subject = "Welcome" };
						var result = await _mailService.SendMailAsync(mailContent);
						await _userManager.AddToRoleAsync(user, UserRole.Customer);
						custom.IdUser = user.Id;
						var result3 = await _customerService.Register(custom);
						if (result3)
						{
							return Redirect("/Index");
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
							return RedirectToPage("User/ConfirmEmail");
						}
						await _signInManager.SignInAsync(user, isPersistent: false);
						return RedirectToPage("/Index");
					}
				}
				
            }
			return Page();
		}
	}
}
