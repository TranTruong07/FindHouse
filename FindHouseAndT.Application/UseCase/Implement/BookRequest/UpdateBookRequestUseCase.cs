using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public class UpdateBookRequestUseCase : IUpdateBookRequestUseCase
	{
		private readonly IBookRequestRepository _bookRequestRepository;

		public UpdateBookRequestUseCase(IBookRequestRepository bookRequestRepository)
		{
			_bookRequestRepository = bookRequestRepository;
		}
		public void Execute(BookRequest bookRequest)
		{
			_bookRequestRepository.UpdateBookRequest(bookRequest);
		}
	}
}
