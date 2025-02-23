using FindHouseAndT.Application.Services;
using FindHouseAndT.Application.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMotelService _motelService;
        public List<MotelManagerDTO> ListMotels { get; set; } = new List<MotelManagerDTO>();

        public IndexModel(IMotelService motelService) {
            _motelService = motelService;
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
