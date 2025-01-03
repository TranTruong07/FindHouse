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
            ListMotels = await _motelService.GetAllMotelAsync();
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
