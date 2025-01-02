using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Helper;

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

        public async Task<ResultStatus> Register(Customer customer)
        {
            await _regisCustomerUseCase.ExecuteAsync(customer);
			var result = await _unitOfWork.CommitAsync();
			if (result != 0)
			{
				return ResultStatus.Success;
			}
			return ResultStatus.Failure;
		}
        public Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return _getCustomerUseCase.ExecuteAsync(id);
        }
        public async Task<ResultStatus> UpdateCustomer(Customer customer)
        {
            await _updateCustomerUseCase.ExecuteAsync(customer);
            var result = await _unitOfWork.CommitAsync();
            if(result != 0)
            {
                return ResultStatus.Success;
            }
            return ResultStatus.Failure;
        }
    }
}
