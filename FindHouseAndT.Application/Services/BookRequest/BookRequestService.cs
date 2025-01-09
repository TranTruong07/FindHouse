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
		private readonly IGetAllBookRequestUseCase getAllBookRequestUseCase;
		private readonly AWSService amazonService;
        private readonly IUnitOfWork unitOfWork;

		public BookRequestService(ICreateBookRequestUseCase createBookRequestUseCase, IGetAllBookRequestUseCase getAllBookRequestUseCase, AWSService amazonService, IGetBookRequestByCustomerIdUseCase getBookRequestByCustomerIdUseCase, IUnitOfWork unitOfWork)
		{
			this.createBookRequestUseCase = createBookRequestUseCase;
			this.unitOfWork = unitOfWork;
			this.getBookRequestByCustomerIdUseCase = getBookRequestByCustomerIdUseCase;
			this.amazonService = amazonService;
			this.getAllBookRequestUseCase = getAllBookRequestUseCase;
		}

		public async Task<ResultStatus> CreateNewBookRequestAsync(BookRequestCreateDTO bookRequestDTO)
		{
            var keyImgBack = await amazonService.UploadImageToAWSAsync(bookRequestDTO.ImgBackCCCD);
            var keyImgFront = await amazonService.UploadImageToAWSAsync(bookRequestDTO.ImgFrontCCCD);
			if(keyImgBack != null && keyImgFront != null)
			{
                var bookRequest = new BookRequest()
                {
                    Address = bookRequestDTO.Address,
                    DateOfBirth = bookRequestDTO.DateOfBirth,
                    FullName = bookRequestDTO.FullName,
                    IdCustomer = bookRequestDTO.IdCustomer,
                    RoomId = bookRequestDTO.RoomId,
                    Status = BookRequestStatus.WaitForAccept,
                    KeyUrlBackCCCD = keyImgBack,
                    KeyUrlFrontCCCD = keyImgFront,
                    Note = bookRequestDTO.Note,
					StartTimeBook = bookRequestDTO.StartTimeBook,
					EndTimeBook = bookRequestDTO.EndTimeBook
                };
                //Create Book Request
                await createBookRequestUseCase.ExecuteAsync(bookRequest);
                var result = await unitOfWork.CommitAsync();
                if (result != 0)
                {
                    return ResultStatus.Success;
                }
            }
			return ResultStatus.Failure;
		}

        public async Task<List<BookRequestCreateDTO>> GetAllBookRequestByCustomerIdAsync(Guid customerId)
        {
			var bookRequest = await getBookRequestByCustomerIdUseCase.ExecuteAsync(customerId);
			List<BookRequestCreateDTO> list = new List<BookRequestCreateDTO>();
			foreach(var br in bookRequest)
			{
				list.Add(new BookRequestCreateDTO
				{
					Address = br.Address,
					DateOfBirth = br.DateOfBirth,
					FullName = br.FullName,
					IdCustomer = customerId,
					Note = br.Note,
					RoomId = br.RoomId,
					UrlBackCCCD = await amazonService.GetPreSignedUrlAsync(br.KeyUrlBackCCCD),
					UrlFrontCCCD = await amazonService.GetPreSignedUrlAsync(br.KeyUrlFrontCCCD),
					Status = br.Status,
					RoomCode = br.Room.RoomCode
				});
			}
			return list;
        }
		public async Task<List<BookRequestShowListDTO>> GetAllBookRequestForShowListAsync()
        {
			try
			{
				var bookRequest = await getAllBookRequestUseCase.ExecuteAsync();
				List<BookRequestShowListDTO> list = new List<BookRequestShowListDTO>();
				foreach (var br in bookRequest)
				{
					list.Add(new BookRequestShowListDTO
					{
						Id = br.Id,
						Address = br.Address,
						DateOfBirth = br.DateOfBirth,
						FullName = br.FullName,
						IdCustomer = br.IdCustomer,
						Note = br.Note,
						UrlBackCCCD = await amazonService.GetPreSignedUrlAsync(br.KeyUrlBackCCCD),
						UrlFrontCCCD = await amazonService.GetPreSignedUrlAsync(br.KeyUrlFrontCCCD),
						Status = br.Status,
						RoomCode = br.Room.RoomCode,
						StartTimeBook = br.StartTimeBook,
						EndTimeBook = br.EndTimeBook
					});
				}
				return list;
			}catch(Exception ex)
			{
                await Console.Out.WriteLineAsync(ex.Message);
				return null;
            }
        }
    }
}
