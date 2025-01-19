using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public class GetBookRequestByIdUseCase : IGetBookRequestByIdUseCase
	{
		private readonly IBookRequestRepository _bookRequestRepository;

		public GetBookRequestByIdUseCase(IBookRequestRepository bookRequestRepository)
		{
			_bookRequestRepository = bookRequestRepository;
		}
		public Task<BookRequest?> ExecuteAsync(int id)
		{
			return _bookRequestRepository.GetBookRequestById(id);
		}
	}
}
