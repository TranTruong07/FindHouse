using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.Services.Common;
using FindHouseAndT.WebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.ManagerPages
{
    public class RoomManagerModel : PageModel
    {
        private readonly AWSService _AwsService;
        private readonly RoomService _roomService;

        public RoomManagerModel(AWSService awsService, RoomService roomService)
        {
            _AwsService = awsService;
            _roomService = roomService;
        }
        [BindProperty]
        public RoomManagerDTO RoomManagerDTO { get; set; } = new RoomManagerDTO();
        public void OnGet()
        {
        }
    }
}
