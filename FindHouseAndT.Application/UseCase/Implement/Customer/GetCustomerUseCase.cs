using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class GetCustomerUseCase : IGetCustomerUseCase
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerUseCase(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer?> ExecuteAsync(Guid customerId)
        {
            if(customerId.CompareTo(Guid.Empty) == 0)
            {
                return null;
            }
            return await _repository.GetCustomerByIdAsync(customerId);
        }
    }
}
