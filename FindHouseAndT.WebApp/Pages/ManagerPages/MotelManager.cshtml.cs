using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.Services.Common;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using FindHouseAndT.WebApp.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.ManagerPages
{
    [Authorize(Roles = UserRole.Landlord)]
    public class MotelManagerModel : PageModel
    {
        private readonly AWSService _AwsService;
        private readonly MotelService _MotelService;

		public MotelManagerModel(AWSService awsService, MotelService motelService)
		{
			_AwsService = awsService;
			_MotelService = motelService;
		}

		[BindProperty]
        public MotelManagerDTO MotelManagerDTO { get; set; } = new MotelManagerDTO();
        public List<MotelManagerDTO> ListMotel { get; set; } = new List<MotelManagerDTO>();
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
			var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
			if (ModelState.IsValid && userIdClaim != null)
            {
				if (MotelManagerDTO.IdMotel.Equals(Guid.Empty))
				{
					var keyImage = await _AwsService.UploadImageToAWSAsync(MotelManagerDTO.ImageFIle);
                    if(keyImage != null)
                    {
						Motel motel = new Motel() 
                        { 
                            Name = MotelManagerDTO.Name, 
                            Address = MotelManagerDTO.Address, 
                            Description1 = MotelManagerDTO.Description1, 
                            IdHouseOwner = Guid.Parse(userIdClaim.Value), 
                            KeyImageMotel = keyImage, 
                            QuantityRoom = MotelManagerDTO.QuantityRoom,
                            Description2 = MotelManagerDTO.Description2,
                        };
                        ResultStatus result =  await _MotelService.CreateMotelAsync(motel);
                        if(result.ResultCode == ResultCode.Success)
                        {
                            return RedirectToPage("/ManagerPages/MotelManager");
                        }
					}

				}
                //else
                //{
                //    // update
                //}

			}
           
            return Page();
        }
    }
}
