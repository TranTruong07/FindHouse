using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Helper;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Application.ExternalInterface;

namespace FindHouseAndT.WebApp.Pages.CustomerPages.CustomerView
{
	[Authorize(Roles = UserRole.Customer)]
	public class BookRequestManagerModel : PageModel
	{
		[BindProperty(SupportsGet = true)]
		public string RoomCode { get; set; } = string.Empty;
		[BindProperty(SupportsGet = true)]
		public Guid IdMotel { get; set; } = new Guid();
		private readonly IRoomService roomService;
		private readonly IFileStorageService amazonService;
		private readonly ICustomerService customerService;
		private readonly IBookRequestService bookRequestService;
		private readonly UserManager<UserApp> userManager;

		public BookRequestManagerModel(IRoomService roomService, UserManager<UserApp> userManager, IFileStorageService amazonService, ICustomerService customerService, IBookRequestService bookRequestService)
		{
			this.roomService = roomService;
			this.amazonService = amazonService;
			this.customerService = customerService;
			this.bookRequestService = bookRequestService;
			this.userManager = userManager;
		}
		[BindProperty]
		public BookRequestCreateDTO BookRequestDTO { get; set; } = new BookRequestCreateDTO();

		public async Task<IActionResult> OnGetAsync()
		{
			var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
			if (!string.IsNullOrEmpty(RoomCode) && userIdClaim != null)
			{
				BookRequestDTO = await bookRequestService.GetInforBookRequestCreateDTOAsync(Guid.Parse(userIdClaim.Value), RoomCode, IdMotel);
				return Page();
			}
			else
			{
				return RedirectToPage("/CustomerPages/CommonView/AccessDenied");
			}
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
			if (userIdClaim != null && ModelState.IsValid)
			{
				BookRequestDTO.IdCustomer = Guid.Parse(userIdClaim.Value);
                var result = await bookRequestService.CreateNewBookRequestAsync(BookRequestDTO);
                if (result.ResultCode == ResultCode.Success)
                {
                    return RedirectToPage("/CustomerPages/CustomerView/ListBookRequest");
                }
			}
			return RedirectToPage("/CustomerPages/CommonView/AccessDenied");
		}
	}
}
