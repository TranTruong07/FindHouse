using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Helper;
using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.ExternalInterface;

namespace FindHouseAndT.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisCustomerUseCase _regisCustomerUseCase;
        private readonly IGetCustomerUseCase _getCustomerUseCase;
        private readonly IUpdateCustomerUseCase _updateCustomerUseCase;
        private readonly IFileStorageService _fileStorageService;

        public CustomerService(IUnitOfWork unitOfWork, IFileStorageService fileStorageService, IRegisCustomerUseCase regisCustomerUseCase, IGetCustomerUseCase getCustomerUseCase, IUpdateCustomerUseCase updateCustomerUseCase)
        {
            _unitOfWork = unitOfWork;
            _regisCustomerUseCase = regisCustomerUseCase;
            _getCustomerUseCase = getCustomerUseCase;
            _updateCustomerUseCase = updateCustomerUseCase;
            _fileStorageService = fileStorageService;
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

		public async Task<ProfileCustomerDTO> GetProfileCustomerAsync(Guid customerId)
		{
			ProfileCustomerDTO profileUserDTO = new ProfileCustomerDTO();
            var customer = await GetCustomerByIdAsync(customerId);
            if(customer != null)
            {
                profileUserDTO.Id = customer.UserApp.Id;
                profileUserDTO.BirthDate = customer.BirthDate;
                profileUserDTO.Name = customer.Name;
                profileUserDTO.Email = customer.UserApp.Email;
                profileUserDTO.UrlAvatar = await _fileStorageService.GetPreSignedUrlAsync(customer.Avatar);
			}
			return profileUserDTO;
		}

		public Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return _getCustomerUseCase.ExecuteAsync(id);
        }
        public async Task<ResultStatus> UpdateCustomer(ProfileCustomerDTO customerDTO)
        {
            var customer = await GetCustomerByIdAsync(customerDTO.Id);
            if(customer != null)
            {
				customer.Name = customerDTO.Name;
				customer.BirthDate = customerDTO.BirthDate;
				var key = await _fileStorageService.UploadImageAsync(customerDTO.Avatar);
				if (key != null)
				{
					var preSignedUrl = await _fileStorageService.GetPreSignedUrlAsync(key);
					if (preSignedUrl != null)
					{
						customerDTO.UrlAvatar = preSignedUrl;
					}
					customer.Avatar = key;
				}
				else
				{
					var preSignedUrl = await _fileStorageService.GetPreSignedUrlAsync(customer.Avatar!);
					if (preSignedUrl != null)
					{
						customerDTO.UrlAvatar = preSignedUrl;
					}
				}
				await _updateCustomerUseCase.ExecuteAsync(customer);
				var result = await _unitOfWork.CommitAsync();
				if (result != 0)
				{
					return ResultStatus.Success;
				}
			}
            return ResultStatus.Failure;
        }
    }
}
