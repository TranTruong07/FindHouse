using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase.Interface.Customer;
using FindHouseAndT.Application.UseCase.Interface.UserApp;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisUserAppUseCase _regisUserAppUseCase;
        private readonly IRegisCustomerUseCase _regisCustomerUseCase;

        public CustomerService(IUnitOfWork unitOfWork, IRegisUserAppUseCase userAppUseCase, IRegisCustomerUseCase regisCustomerUseCase)
        {
            _unitOfWork = unitOfWork;
            _regisUserAppUseCase = userAppUseCase;
            _regisCustomerUseCase = regisCustomerUseCase;
        }

        public async Task<bool> Register(UserApp userApp, Customer customer)
        {
            await _regisUserAppUseCase.ExecuteAsync(userApp);
            await _unitOfWork.CommitAsync();
            await _regisCustomerUseCase.ExecuteAsync(customer);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
