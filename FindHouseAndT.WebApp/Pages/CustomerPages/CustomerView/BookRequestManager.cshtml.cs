using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Helper;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.CustomerPages.CustomerView
{
	[Authorize(Roles = UserRole.Customer)]
	public class BookRequestManagerModel : PageModel
	{
		[BindProperty(SupportsGet = true)]
		public string RoomCode { get; set; } = string.Empty;
		private readonly RoomService roomService;
		private readonly AWSService amazonService;
		private readonly CustomerService customerService;
		private readonly BookRequestService bookRequestService;

		public BookRequestManagerModel(RoomService roomService, AWSService amazonService, CustomerService customerService, BookRequestService bookRequestService)
		{
			this.roomService = roomService;
			this.amazonService = amazonService;
			this.customerService = customerService;
			this.bookRequestService = bookRequestService;
		}
		public RoomManagerDTO RoomManagerDTO { get; set; } = new RoomManagerDTO();
		[BindProperty]
		public BookRequestCreateDTO BookRequestDTO { get; set; } = new BookRequestCreateDTO();

		public async Task<IActionResult> OnGetAsync()
		{
			var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
			if (!string.IsNullOrEmpty(RoomCode) && userIdClaim != null)
			{
				var room = await roomService.GetRoomByRoomCodeAsync(RoomCode);
				if (room == null)
				{
					return RedirectToPage("/CustomerPages/CommonView/AccessDenied");
				}
				RoomManagerDTO.RoomCode = room.RoomCode;
				RoomManagerDTO.UrlImageRoom = await amazonService.GetPreSignedUrlAsync(room.KeyImageRoom);

				var customer = await customerService.GetCustomerByIdAsync(Guid.Parse(userIdClaim.Value));
				if (customer == null)
				{
					return RedirectToPage("/CustomerPages/CommonView/AccessDenied");
				}
				BookRequestDTO.DateOfBirth = customer.BirthDate ?? new DateOnly();
				BookRequestDTO.RoomId = room.ID;
				BookRequestDTO.FullName = customer.Name;
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
			var br = BookRequestDTO;
			return RedirectToPage("/CustomerPages/CommonView/AccessDenied");
		}
	}
}
