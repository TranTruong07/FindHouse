using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.ManagerPages
{
    [Authorize(Roles = UserRole.Landlord)]
    public class CreateContractModel : PageModel
    {
        private readonly IBookRequestService bookRequestService;

		public CreateContractModel(IBookRequestService bookRequestService)
		{
			this.bookRequestService = bookRequestService;
		}

		[BindProperty(SupportsGet = true)]
        public int BookRequestId { get; set; }
        [BindProperty]
		public CreateContractDTO createContractDTO { get; set; } = new CreateContractDTO();
		public async Task<IActionResult> OnGetAsync()
        {
            var userIdClaim = User.FindFirst(x => x.Type.Equals(System.Security.Claims.ClaimTypes.NameIdentifier));
            if(userIdClaim != null && BookRequestId != 0)
            {
                var bookRequest = await bookRequestService.GetBookRequestByIdAsync(BookRequestId);
                if(bookRequest != null)
                {
					createContractDTO.IdCustomer = bookRequest.IdCustomer;
                    createContractDTO.IdRoom = bookRequest.Id;
                    createContractDTO.FullNameCustomer = bookRequest.FullName;
                    createContractDTO.PhoneCustomer = bookRequest.PhoneNumber;
                    createContractDTO.StartDate = bookRequest.StartTimeBook;
                    createContractDTO.EndDate = bookRequest.EndTimeBook;
                    createContractDTO.Room = bookRequest.Room;
                    createContractDTO.BookRequestId = BookRequestId;
                    return Page();
				}
			}
			return RedirectToPage("/CustomerPages/CommonView/AccessDenied");
		}
        public void OnPostAsync()
        {
            var contract = createContractDTO;
        }
    }
}
