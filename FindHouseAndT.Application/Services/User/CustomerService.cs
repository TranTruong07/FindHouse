using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase.Interface.Customer;
using FindHouseAndT.Application.UseCase.Interface.UserApp;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisCustomerUseCase _regisCustomerUseCase;

        public CustomerService(IUnitOfWork unitOfWork, IRegisCustomerUseCase regisCustomerUseCase)
        {
            _unitOfWork = unitOfWork;
            _regisCustomerUseCase = regisCustomerUseCase;
        }

        public async Task<bool> Register(Customer customer)
        {
            await _regisCustomerUseCase.ExecuteAsync(customer);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
