using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.Services
{
	public interface IBookRequestService
	{
		Task<ResultStatus> UpdateStatusBookRequestAsync(int bookRequestId, string BookRequestStatus);
		Task<ResultStatus> CreateNewBookRequestAsync(BookRequestCreateDTO bookRequestDTO);
		Task<List<BookRequestShowListDTO>> GetAllBookRequestByCustomerIdAsync(Guid customerId);
		Task<List<BookRequestShowListDTO>> GetAllBookRequestForShowListAsync();
		Task<BookRequest?> GetBookRequestByIdAsync(int bookRequestId);
		Task<BookRequestCreateDTO> GetInforBookRequestCreateDTOAsync(Guid customerId, string roomCode, Guid IdMotel);
	}
}
