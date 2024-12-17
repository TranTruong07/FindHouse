using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
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
        private readonly UserManager<UserApp> _userManager;
        private readonly CustomerService _customerService;
		public RegisterUserModel(UserManager<UserApp> userManager, CustomerService customerService)
		{
            _userManager = userManager;
            _customerService = customerService;
		}

		public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() {
            if(ModelState.IsValid)
            {
                var result1 = await _userManager.FindByEmailAsync(RegisterDTO.Email);
                if(result1 != null)
                {
                    ModelState.AddModelError("Email", "Email is exist.");
                }
                else
                {
                    var user = new UserApp()
                    {
                        UserName = RegisterDTO.Email,
                        Email = RegisterDTO.Email,
                        EmailConfirmed = true
                    };
                    var custom = new Customer()
                    {
                        Name = RegisterDTO.FullName,
                        BirthDate = RegisterDTO.BirthDate.ToDateTime(TimeOnly.MinValue),
                    };
					var result2 = await _userManager.CreateAsync(user, RegisterDTO.Password);
                    if(result2.Succeeded)
                    {
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
    }
}
