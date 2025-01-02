using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.Services
{
	public class BookRequestService
	{
		private readonly ICreateBookRequestUseCase createBookRequestUseCase;
		private readonly IGetBookRequestByCustomerIdUseCase getBookRequestByCustomerIdUseCase;
		private readonly AWSService amazonService;
        private readonly IUnitOfWork unitOfWork;

		public BookRequestService(ICreateBookRequestUseCase createBookRequestUseCase, AWSService amazonService, IGetBookRequestByCustomerIdUseCase getBookRequestByCustomerIdUseCase, IUnitOfWork unitOfWork)
		{
			this.createBookRequestUseCase = createBookRequestUseCase;
			this.unitOfWork = unitOfWork;
			this.getBookRequestByCustomerIdUseCase = getBookRequestByCustomerIdUseCase;
			this.amazonService = amazonService;
		}

		public async Task<ResultStatus> CreateNewBookRequestAsync(BookRequest bookRequest)
		{
			await createBookRequestUseCase.ExecuteAsync(bookRequest);
			var result = await unitOfWork.CommitAsync();
			if(result != 0)
			{
				return ResultStatus.Success;
			}
			return ResultStatus.Failure;
		}

        public async Task<List<BookRequestDTO>> GetAllBookRequestByCustomerIdAsync(Guid customerId)
        {
			var bookRequest = await getBookRequestByCustomerIdUseCase.ExecuteAsync(customerId);
			List<BookRequestDTO> list = new List<BookRequestDTO>();
			foreach(var br in bookRequest)
			{
				list.Add(new BookRequestDTO
				{
					Address = br.Address,
					DateOfBirth = br.DateOfBirth,
					FullName = br.FullName,
					IdCustomer = customerId,
					Note = br.Note,
					RoomCode = br.RoomCode,
					UrlBackCCCD = await amazonService.GetPreSignedUrlAsync(br.KeyUrlBackCCCD),
					UrlFrontCCCD = await amazonService.GetPreSignedUrlAsync(br.KeyUrlFrontCCCD),
					Status = br.Status
				});
			}
			return list;
        }
    }
}
