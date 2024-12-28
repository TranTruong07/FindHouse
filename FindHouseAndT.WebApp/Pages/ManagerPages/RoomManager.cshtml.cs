using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.Services.Common;
using FindHouseAndT.WebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Authorization;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.WebApp.Pages.ManagerPages
{
    [Authorize(Roles = UserRole.Landlord)]
    public class RoomManagerModel : PageModel
    {
        private readonly AWSService _AwsService;
        private readonly RoomService _roomService;
        private readonly MotelService _motelService;

        public RoomManagerModel(AWSService awsService, RoomService roomService, MotelService motelService)
        {
            _AwsService = awsService;
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
                var keyImage = await _AwsService.UploadImageToAWSAsync(RoomManagerDTO.ImageRoom);
                if (keyImage != null)
                {
                    var room = new Room()
                    {
                        RoomCode = RoomManagerDTO.RoomCode,
                        Description1 = RoomManagerDTO.Description1,
                        KeyImageRoom = keyImage,
                        Status = RoomStatus.Available,
                        Description2 = RoomManagerDTO.Description2,
                        Floor = RoomManagerDTO.Floor,
                        Area = RoomManagerDTO.Area,
                        Price = RoomManagerDTO.Price,
                        IdMotel = RoomManagerDTO.IdMotel,
                    };
                    ResultStatus result = await _roomService.CreateNewRoomAsync(room);
                    if(result.ResultCode == ResultCode.Success)
                    {
                        return RedirectToPage("/ManagerPages/RoomManager");
                    }
                }
            }
            var ListMotel = await _motelService.GetAllMotelAsync();
            ViewData["Motels"] = new SelectList(ListMotel, "IdMotel", "Name");
            return Page();
        }
    }
}
