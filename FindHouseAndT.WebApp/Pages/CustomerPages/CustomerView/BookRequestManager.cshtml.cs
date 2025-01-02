using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Entities;
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
		public BookRequestDTO BookRequestDTO { get; set; } = new BookRequestDTO();

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
				BookRequestDTO.RoomCode = room.RoomCode;
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
				var keyImgBack = await amazonService.UploadImageToAWSAsync(BookRequestDTO.ImgBackCCCD);
				var keyImgFront = await amazonService.UploadImageToAWSAsync(BookRequestDTO.ImgFrontCCCD);
				if (keyImgBack != null && keyImgFront != null)
				{
					var bookRequest = new BookRequest()
					{
						Address = BookRequestDTO.Address,
						DateOfBirth = BookRequestDTO.DateOfBirth,
						FullName = BookRequestDTO.FullName,
						IdCustomer = Guid.Parse(userIdClaim.Value),
						RoomCode = BookRequestDTO.RoomCode,
						Status = BookRequestStatus.WaitForAccept,
						KeyUrlBackCCCD = keyImgBack,
						KeyUrlFrontCCCD = keyImgFront,
						Note = BookRequestDTO.Note
					};
					//Create Book Request
					var result = await bookRequestService.CreateNewBookRequestAsync(bookRequest);
					if(result.ResultCode == ResultCode.Success)
					{
						return RedirectToPage("/CustomerPages/CustomerView/ListBookRequest");
					}
				}

			}
			var br = BookRequestDTO;
			return RedirectToPage("/CustomerPages/CommonView/AccessDenied");
		}
	}
}
