using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.ExternalInterface;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.Services
{
	public class BookRequestService : IBookRequestService
	{
		private readonly ICreateBookRequestUseCase createBookRequestUseCase;
		private readonly IUpdateBookRequestUseCase updateBookRequestUseCase;
		private readonly IGetBookRequestByCustomerIdUseCase getBookRequestByCustomerIdUseCase;
		private readonly IGetAllBookRequestUseCase getAllBookRequestUseCase;
		private readonly IGetBookRequestByIdUseCase getBookRequestByIdUseCase;
		private readonly IFileStorageService _fileStorageService;
		private readonly IUnitOfWork unitOfWork;
		private readonly ICustomerService customerService;
		private readonly IRoomService roomService;

		public BookRequestService(
			IRoomService roomService,
			ICustomerService customerService,
			IFileStorageService fileStorageService,
			ICreateBookRequestUseCase createBookRequestUseCase,
			IUpdateBookRequestUseCase updateBookRequestUseCase,
			IGetBookRequestByIdUseCase getBookRequestByIdUseCase,
			IGetAllBookRequestUseCase getAllBookRequestUseCase,
			IGetBookRequestByCustomerIdUseCase getBookRequestByCustomerIdUseCase,
			IUnitOfWork unitOfWork)
		{
			this.createBookRequestUseCase = createBookRequestUseCase;
			this.unitOfWork = unitOfWork;
			this.getBookRequestByCustomerIdUseCase = getBookRequestByCustomerIdUseCase;
			this._fileStorageService = fileStorageService;
			this.getAllBookRequestUseCase = getAllBookRequestUseCase;
			this.getBookRequestByIdUseCase = getBookRequestByIdUseCase;
			this.updateBookRequestUseCase = updateBookRequestUseCase;
			this.customerService = customerService;
			this.roomService = roomService;
		}

		public async Task<ResultStatus> UpdateStatusBookRequestAsync(int bookRequestId, string BookRequestStatus)
		{
			if (bookRequestId != 0)
			{
				var bookRequest = await GetBookRequestByIdAsync(bookRequestId);
				if (bookRequest != null)
				{
					bookRequest.Status = BookRequestStatus;
					updateBookRequestUseCase.Execute(bookRequest);
					var result = await unitOfWork.CommitAsync();
					if (result != 0)
					{
						return ResultStatus.Success;
					}
				}
			}
			return ResultStatus.Failure;
		}

		public async Task<ResultStatus> CreateNewBookRequestAsync(BookRequestCreateDTO bookRequestDTO)
		{
			var keyImgBack = await _fileStorageService.UploadImageAsync(bookRequestDTO.ImgBackCCCD);
			var keyImgFront = await _fileStorageService.UploadImageAsync(bookRequestDTO.ImgFrontCCCD);
			if (keyImgBack != null && keyImgFront != null)
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
					EndTimeBook = bookRequestDTO.EndTimeBook,
					Email = bookRequestDTO.Email,
					PhoneNumber = bookRequestDTO.PhoneNumber
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

		public async Task<List<BookRequestShowListDTO>> GetAllBookRequestByCustomerIdAsync(Guid customerId)
		{
			var bookRequest = await getBookRequestByCustomerIdUseCase.ExecuteAsync(customerId);
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
					UrlBackCCCD = await _fileStorageService.GetPreSignedUrlAsync(br.KeyUrlBackCCCD),
					UrlFrontCCCD = await _fileStorageService.GetPreSignedUrlAsync(br.KeyUrlFrontCCCD),
					Status = br.Status,
					RoomCode = br.Room.RoomCode,
					StartTimeBook = br.StartTimeBook,
					EndTimeBook = br.EndTimeBook,
					Email = br.Email,
					PhoneNumber = br.PhoneNumber
				});
			}
			return list;
		}
		public async Task<List<BookRequestShowListDTO>> GetAllBookRequestForShowListAsync()
		{
			List<BookRequestShowListDTO> list = new List<BookRequestShowListDTO>();
			try
			{
				var bookRequest = await getAllBookRequestUseCase.ExecuteAsync();
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
						UrlBackCCCD = await _fileStorageService.GetPreSignedUrlAsync(br.KeyUrlBackCCCD),
						UrlFrontCCCD = await _fileStorageService.GetPreSignedUrlAsync(br.KeyUrlFrontCCCD),
						Status = br.Status,
						RoomCode = br.Room.RoomCode,
						StartTimeBook = br.StartTimeBook,
						EndTimeBook = br.EndTimeBook,
						Email = br.Email,
						PhoneNumber = br.PhoneNumber
					});
				}
				return list;
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
				return list;
			}
		}

		public Task<BookRequest?> GetBookRequestByIdAsync(int bookRequestId)
		{
			return getBookRequestByIdUseCase.ExecuteAsync(bookRequestId);
		}

		public async Task<BookRequestCreateDTO> GetInforBookRequestCreateDTOAsync(Guid customerId, string roomCode, Guid IdMotel)
		{
			BookRequestCreateDTO bookRequestCreateDTO = new BookRequestCreateDTO();

			var room = await roomService.GetRoomByRoomCodeAndIdMotelAsync(roomCode, IdMotel);
			if (room != null)
			{
				bookRequestCreateDTO.RoomCode = room.RoomCode;
				bookRequestCreateDTO.UrlRoom = await _fileStorageService.GetPreSignedUrlAsync(room.KeyImageRoom);
			}
			var customer = await customerService.GetCustomerByIdAsync(customerId);
			if (customer != null)
			{
				bookRequestCreateDTO.DateOfBirth = customer.BirthDate ?? new DateOnly();
				bookRequestCreateDTO.RoomId = room.ID;
				bookRequestCreateDTO.FullName = customer.Name;
				bookRequestCreateDTO.Email = customer.UserApp.Email;
				bookRequestCreateDTO.PhoneNumber = customer.UserApp.PhoneNumber;
			}
			return bookRequestCreateDTO;
		}
	}
}
