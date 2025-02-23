using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using FindHouseAndT.Models.Helper;
using System.Security.Claims;

namespace FindHouseAndT.WebApp.Pages.CustomerPages
{
    [Authorize(Roles = UserRole.Customer)]
    public class ProfileUserModel : PageModel
    {
        private readonly ICustomerService _customerService;
        [BindProperty]
        public ProfileCustomerDTO ProfileUserDTO { get; set; } = new ProfileCustomerDTO();

        public ProfileUserModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> OnGet()
        {
            var userIdClaims = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaims == null)
            {
                return RedirectToPage("/CustomerPages/CommonView/AccessDenied");
            }
            ProfileUserDTO = await _customerService.GetProfileCustomerAsync(Guid.Parse(userIdClaims.Value));
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _customerService.UpdateCustomer(ProfileUserDTO);
			}
			return Page();
        }
    }
}
