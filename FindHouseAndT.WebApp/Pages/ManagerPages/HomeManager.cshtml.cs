using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.ManagerPages
{
    [Authorize(Roles =UserRole.Landlord)]
    public class HomeManagerModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
