using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.UseCase
{
    public class GetBookRequestByCustomerIdUseCase : IGetBookRequestByCustomerIdUseCase
    {
        private readonly IBookRequestRepository _bookRequestRepository;

        public GetBookRequestByCustomerIdUseCase(IBookRequestRepository bookRequestRepository)
        {
            _bookRequestRepository = bookRequestRepository;
        }

        public Task<List<BookRequest>> ExecuteAsync(Guid customerId)
        {
            return _bookRequestRepository.GetBookRequestsByCustomerIdAsync(customerId);
        }
    }
}
