using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.Services;
using FindHouseAndT.Models.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindHouseAndT.WebApp.Pages.ManagerPages
{
    public class ListBookRequestManagerModel : PageModel
    {
        private IBookRequestService bookRequestService;

        public ListBookRequestManagerModel(IBookRequestService bookRequestService)
        {
            this.bookRequestService = bookRequestService;
        }

        public List<BookRequestShowListDTO> ListBookRequest { get; set; } = new List<BookRequestShowListDTO>();
        public async Task OnGet()
        {
            ListBookRequest = await bookRequestService.GetAllBookRequestForShowListAsync();
        }
        [BindProperty(SupportsGet = true)]
        public int BookRequestId { get; set; }
		public async Task<IActionResult> OnGetLoadBookRequest()
        {
            if(BookRequestId != 0)
            {
                var list = await bookRequestService.GetAllBookRequestForShowListAsync();
                var br = list.Where(x => x.Id == BookRequestId).SingleOrDefault();
                return new JsonResult(br);
            }
            return new JsonResult("Error");
        }

		public async Task<IActionResult> OnGetAcceptAsync()
		{
			if (BookRequestId != 0)
			{
                ResultStatus result = await bookRequestService.UpdateStatusBookRequestAsync(BookRequestId, BookRequestStatus.AcceptRequest);
			    if(result.ResultCode == ResultCode.Success)
                {
					return RedirectToPage("/ManagerPages/ListBookRequestManager");
				}
			}
            return Page();
		}
		public async Task<IActionResult> OnGetRejectAsync()
		{
			if (BookRequestId != 0)
			{
				ResultStatus result = await bookRequestService.UpdateStatusBookRequestAsync(BookRequestId, BookRequestStatus.RejectRequest);
				if (result.ResultCode == ResultCode.Success)
				{
					return RedirectToPage("/ManagerPages/ListBookRequestManager");
				}
			}
			return Page();
		}
	}
}
