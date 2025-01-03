using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public class CreateBookRequestUseCase : ICreateBookRequestUseCase
	{
		private readonly IBookRequestRepository _bookRequestRepository;

		public CreateBookRequestUseCase(IBookRequestRepository bookRequestRepository)
		{
			_bookRequestRepository = bookRequestRepository;
		}

		public Task ExecuteAsync(BookRequest bookRequest)
		{
			_bookRequestRepository.CreateBookRequestAsync(bookRequest);
			return Task.CompletedTask;
		}
	}
}
