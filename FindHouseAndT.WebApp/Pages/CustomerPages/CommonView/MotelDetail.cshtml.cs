using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.CustomerPages.CommonView
{
    public class MotelDetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid MotelId { get; set; }
        public MotelManagerDTO Motel { get; set; } = null!;
        public List<RoomManagerDTO> Rooms { get; set; } = new List<RoomManagerDTO>();
        private readonly MotelService _motelService;
        private readonly AWSService _amazonService;

        public MotelDetailModel(MotelService motelService, AWSService amazonService)
        {
            _motelService = motelService;
            _amazonService = amazonService;
        }

        public async void OnGet()
        {
            if(!MotelId.Equals(Guid.Empty))
            {
                var motel = _motelService.GetMotelById(MotelId);
                if(motel != null)
                {
                    Motel = new MotelManagerDTO()
                    {
                        Address = motel.Address,
                        Description1 = motel.Description1,
                        Description2 = motel.Description2,
                        IdMotel = motel.IdMotel,
                        QuantityRoom = motel.QuantityRoom,
                        Name = motel.Name,
                        ImageMotel = await _amazonService.GetPreSignedUrlAsync(motel.KeyImageMotel)
                    };
                    foreach (var room in motel.Rooms)
                    {
                        Rooms.Add(new RoomManagerDTO()
                        {
                            Area = room.Area,
                            Description1 = room.Description1,
                            Description2= room.Description2,
                            Floor = room.Floor,
                            IdMotel = room.IdMotel,
                            Price = room.Price,
                            Status = room.Status,
                            RoomCode = room.RoomCode,
                            UrlImageRoom = await _amazonService.GetPreSignedUrlAsync(room.KeyImageRoom)
                        });
                    }
                }
                
            }
        }
    }
}
