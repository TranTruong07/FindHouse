using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class GetAllBookRequestUseCase : IGetAllBookRequestUseCase
    {
        private readonly IBookRequestRepository _bookRequestRepository;

        public GetAllBookRequestUseCase(IBookRequestRepository bookRequestRepository)
        {
            _bookRequestRepository = bookRequestRepository;
        }

        public Task<List<BookRequest>> ExecuteAsync()
        {
            return _bookRequestRepository.GetAllBookRequestAsync();
        }
    }
}
