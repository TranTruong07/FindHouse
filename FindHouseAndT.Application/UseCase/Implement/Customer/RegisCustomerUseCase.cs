using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class RegisCustomerUseCase : IRegisCustomerUseCase
    {
        private readonly ICustomerRepository _repository;

        public RegisCustomerUseCase(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExecuteAsync(Customer customer)
        {
            await _repository.CreateCustomerAsync(customer);
            return true;
        }
    }
}
