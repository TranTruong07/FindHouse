using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.WebApp.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.CustomerPages
{
    public class ProfileUserModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly UserManager<UserApp> _userManager;
        private readonly AWSService _aWSService;
        [BindProperty]
        public ProfileUserDTO ProfileUserDTO { get; set; } = new ProfileUserDTO();

        public ProfileUserModel(CustomerService customerService, UserManager<UserApp> userManager, AWSService aWSService)
        {
            _customerService = customerService;
            _userManager = userManager;
            _aWSService = aWSService;
        }

        public async Task<IActionResult> OnGet()
        {
            var userClaims = User;
            if (userClaims == null)
            {
                return RedirectToPage("/CustomerPages/CommonView/UserManager");
            }
            var userName = userClaims.Identity?.Name;
            if(string.IsNullOrEmpty(userName))
            {
                return RedirectToPage("/CustomerPages/CommonView/Index");
            }
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return RedirectToPage("/CustomerPages/CommonView/Index");
            }
            var customer = await _customerService.GetCustomerByIdAsync(user.Id);
            if (customer == null)
            {
                return RedirectToPage("/CustomerPages/CommonView/Index");
            }
            var urlAvatar = string.IsNullOrEmpty(customer.Avatar) ? null : await _aWSService.GetPreSignedUrl(customer.Avatar!);
			ProfileUserDTO = new ProfileUserDTO()
            {
                Id = user.Id,
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                Email = user.Email,
                UrlAvatar = urlAvatar

			};
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(ProfileUserDTO.Name))
                {
                    ModelState.AddModelError("ErrorName", "Name is require.");
					return Page();
				}
                var userName = User.Identity?.Name;
				if (string.IsNullOrEmpty(userName))
				{
					ModelState.AddModelError("ErrorUserName", "Not found UserName");
					return Page();
				}
                var user = await _userManager.FindByNameAsync(userName);
				if (user == null)
				{
					ModelState.AddModelError("ErrorUser", "Not found User");
					return Page();
				}
				var customer = await _customerService.GetCustomerByIdAsync(user.Id);
				if (customer == null)
				{
					ModelState.AddModelError("ErrorCustomer", "Not found Customer");
					return Page();
				}
				customer.Name = ProfileUserDTO.Name;
				var key = await _aWSService.UploadImageToAWSAsync(ProfileUserDTO.Avatar);
				customer.BirthDate = ProfileUserDTO.BirthDate;
				if (key != null)
				{
					var preSignedUrl = await _aWSService.GetPreSignedUrl(key);
					if(preSignedUrl != null)
                    {
                        ProfileUserDTO.UrlAvatar = preSignedUrl;
                    }
                    customer.Avatar = key;
                }
                else
                {
					var preSignedUrl = await _aWSService.GetPreSignedUrl(customer.Avatar!);
                    if(preSignedUrl != null)
                    {
                        ProfileUserDTO.UrlAvatar = preSignedUrl;
                    }
				}
                await _customerService.UpdateCustomer(customer);
			}
            

			return Page();
        }
    }
}
