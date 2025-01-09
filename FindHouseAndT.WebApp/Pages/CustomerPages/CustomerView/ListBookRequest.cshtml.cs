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
        private readonly BookRequestService bookRequestService;

        public ListBookRequestModel(BookRequestService bookRequestService)
        {
            this.bookRequestService = bookRequestService;
        }

        public List<BookRequestCreateDTO> Books { get; set; } = new List<BookRequestCreateDTO>();
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
    }
}
