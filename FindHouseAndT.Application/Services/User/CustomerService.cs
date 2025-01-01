using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Application.UseCase;

namespace FindHouseAndT.Application.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisCustomerUseCase _regisCustomerUseCase;
        private readonly IGetCustomerUseCase _getCustomerUseCase;
        private readonly IUpdateCustomerUseCase _updateCustomerUseCase;

        public CustomerService(IUnitOfWork unitOfWork, IRegisCustomerUseCase regisCustomerUseCase, IGetCustomerUseCase getCustomerUseCase, IUpdateCustomerUseCase updateCustomerUseCase)
        {
            _unitOfWork = unitOfWork;
            _regisCustomerUseCase = regisCustomerUseCase;
            _getCustomerUseCase = getCustomerUseCase;
            _updateCustomerUseCase = updateCustomerUseCase;
        }

        public async Task<bool> Register(Customer customer)
        {
            await _regisCustomerUseCase.ExecuteAsync(customer);
            await _unitOfWork.CommitAsync();
            return true;
        }
        public async Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return await _getCustomerUseCase.ExecuteAsync(id);
        }
        public async Task<bool> UpdateCustomer(Customer customer)
        {
            await _updateCustomerUseCase.ExecuteAsync(customer);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
