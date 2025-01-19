using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FindHouseAndT.WebApp.Pages.CustomerPages.CustomerView
{
    [Authorize(Roles = UserRole.Customer)]
    public class ListBookRequestModel : PageModel
    {
        private readonly IBookRequestService bookRequestService;

        public ListBookRequestModel(IBookRequestService bookRequestService)
        {
            this.bookRequestService = bookRequestService;
        }

        public List<BookRequestShowListDTO> Books { get; set; } = new List<BookRequestShowListDTO>();
        public async Task<IActionResult> OnGet()
        {
            var claimUserId = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier);
            if(claimUserId == null)
            {
                return RedirectToPage("");
            }
            Books = await bookRequestService.GetAllBookRequestByCustomerIdAsync(Guid.Parse(claimUserId.Value));
            return Page();
        }
        [BindProperty(SupportsGet = true)]
        public int BookRequestId { get; set; }
        public async Task<IActionResult> OnGetLoadBookRequest()
        {
            if (BookRequestId != 0)
            {
                var list = await bookRequestService.GetAllBookRequestForShowListAsync();
                var br = list.Where(x => x.Id == BookRequestId).SingleOrDefault();
                return new JsonResult(br);
            }
            return new JsonResult("Error");
        }
    }
}
