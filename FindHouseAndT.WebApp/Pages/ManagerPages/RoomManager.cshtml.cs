using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Authorization;

namespace FindHouseAndT.WebApp.Pages.ManagerPages
{
	[Authorize(Roles = UserRole.Landlord)]
	public class RoomManagerModel : PageModel
	{
		private readonly IRoomService _roomService;
		private readonly IMotelService _motelService;

		public RoomManagerModel(IRoomService roomService, IMotelService motelService)
		{
			_roomService = roomService;
			_motelService = motelService;
		}
		[BindProperty]
		public RoomManagerDTO RoomManagerDTO { get; set; } = new RoomManagerDTO();
		public async Task OnGetAsync()
		{
			var ListMotel = await _motelService.GetAllMotelAsync();
			ViewData["Motels"] = new SelectList(ListMotel, "IdMotel", "Name");
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				if (RoomManagerDTO.Id == 0)
				{
					ResultStatus result = await _roomService.CreateNewRoomAsync(RoomManagerDTO);
					if (result.ResultCode == ResultCode.Success)
					{
						return RedirectToPage("/ManagerPages/RoomManager");
					}

				}
				else
				{
					ResultStatus result = await _roomService.UpdateRoomAsync(RoomManagerDTO);
					if (result.ResultCode == ResultCode.Success)
					{
						return RedirectToPage("/ManagerPages/RoomManager");
					}
				}

			}
			var ListMotel = await _motelService.GetAllMotelAsync();
			ViewData["Motels"] = new SelectList(ListMotel, "IdMotel", "Name");
			return Page();
		}
		[BindProperty(SupportsGet = true)]
		public Guid MotelId { get; set; }
		public async Task<IActionResult> OnGetLoadRoom()
		{
			if (!MotelId.Equals(Guid.Empty))
			{
				var listRoom = await _roomService.GetAllRoomDTOsByMotelIdAsync(MotelId);
				return new JsonResult(listRoom);
			}
			return new JsonResult("Error");
		}
	}
}
