using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Helper;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.ManagerPages
{
    [Authorize(Roles = UserRole.Landlord)]
    public class MotelManagerModel : PageModel
    {
        private readonly IMotelService _MotelService;

		public MotelManagerModel(IMotelService motelService)
		{
			_MotelService = motelService;
		}

		[BindProperty]
        public MotelManagerDTO MotelManagerDTO { get; set; } = new MotelManagerDTO();
        public List<MotelManagerDTO> ListMotel { get; set; } = new List<MotelManagerDTO>();
        public async Task OnGetAsync()
        {
            ListMotel = await _MotelService.GetAllMotelAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
			var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
			if (ModelState.IsValid && userIdClaim != null)
            {
                MotelManagerDTO.IdHouseOwner = Guid.Parse(userIdClaim.Value);
				if (MotelManagerDTO.IdMotel.Equals(Guid.Empty))
				{
                    MotelManagerDTO.IdHouseOwner = Guid.Parse(userIdClaim.Value);
                    ResultStatus result = await _MotelService.CreateMotelAsync(MotelManagerDTO);
					if (result.ResultCode == ResultCode.Success)
					{
						return RedirectToPage("/ManagerPages/MotelManager");
					}
				}
                else
                {
                    ResultStatus result = await _MotelService.UpdateMotel(MotelManagerDTO);
                    if (result.ResultCode == ResultCode.Success)
                    {
                        return RedirectToPage("/ManagerPages/MotelManager");
                    }
                }

            }
           
            return Page();
        }
    }
}
