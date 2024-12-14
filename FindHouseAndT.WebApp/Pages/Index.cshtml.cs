using FindHouseAndT.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MotelService _motelService;


        public IndexModel(ILogger<IndexModel> logger, MotelService motelService) {
            _logger = logger;
            _motelService = motelService;
        }

        public void OnGet()
        {

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
