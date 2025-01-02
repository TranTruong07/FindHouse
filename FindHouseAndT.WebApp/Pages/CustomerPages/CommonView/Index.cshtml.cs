using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MotelService _motelService;
        private readonly AWSService _amazonService;
        public List<MotelManagerDTO> ListMotels { get; set; } = new List<MotelManagerDTO>();

        public IndexModel(ILogger<IndexModel> logger, MotelService motelService, AWSService aWS) {
            _logger = logger;
            _motelService = motelService;
            _amazonService = aWS;
        }

        public async Task OnGet()
        {
            var listMotel = await _motelService.GetAllMotelAsync();
            foreach (var motel in listMotel)
            {
                ListMotels.Add(new MotelManagerDTO
                {
                    Address = motel.Address,
                    IdMotel = motel.IdMotel,
                    Description1 = motel.Description1,
                    Description2 = motel.Description2,
                    IdHouseOwner = motel.IdHouseOwner,
                    Name = motel.Name,
                    QuantityRoom = motel.QuantityRoom,
                    ImageMotel = await _amazonService.GetPreSignedUrlAsync(motel.KeyImageMotel)
                });
			}
        }
        public void OnPost(Guid idMotel)
        {
            var motel = _motelService.GetMotelById(idMotel);
            if (motel != null)
            {
                ViewData["motel"] = motel;
            }
        }
    }
}
