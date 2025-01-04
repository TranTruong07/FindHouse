using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.DTOs;
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
                if(RoomManagerDTO.Id == 0)
                {
                    var room = await _roomService.GetRoomByRoomCodeAsync(RoomManagerDTO.OldRoomCode);
                    if (room == null)
                    {
                        ResultStatus result = await _roomService.CreateNewRoomAsync(RoomManagerDTO);
                        if (result.ResultCode == ResultCode.Success)
                        {
                            return RedirectToPage("/ManagerPages/RoomManager");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate", "RoomCode is duplicate");
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
        [BindProperty(SupportsGet =true)]
        public Guid MotelId { get; set; }
        public async Task<IActionResult> OnGetLoadRoom()
        {
            if (!MotelId.Equals(Guid.Empty))
            {
                var listRoom = await _roomService.GetAllRoomsByMotelIdAsync(MotelId);
                var rooms = new List<RoomManagerDTO>();
                foreach(var room in listRoom)
                {
                    rooms.Add(new RoomManagerDTO()
                    {
                        Id = room.ID,
                        RoomCode = room.RoomCode,
                        Area = room.Area,
                        Price = room.Price,
                        IdMotel = room.IdMotel,
                        Description1 = room.Description1,
                        Description2 = room.Description2,
                        Floor = room.Floor,
                        Status = room.Status,
                        UrlImageRoom = await _AwsService.GetPreSignedUrlAsync(room.KeyImageRoom)
                    });
                }
                return new JsonResult(rooms);
            }
            return new JsonResult("Error");
        }
    }
}
