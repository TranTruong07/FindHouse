using Amazon.Runtime;
using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.ExternalInterface;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.Services
{
	public class RoomService : IRoomService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly ICreateNewRoomUseCase createNewRoomUseCase;
		private readonly IGetAllRoomsByMotelIdUseCase getRoomsByMotelIdUseCase;
		private readonly IGetRoomByRoomCodeAndIdMotelUseCase getRoomByRoomCodeAndIdMotelUseCase;
		private readonly IUpdateRoomUseCase updateRoomUseCase;
		private readonly IGetRoomByIdUseCase getRoomByIdUseCase;
		private readonly IFileStorageService _fileStorageService;
		public RoomService(IUnitOfWork unitOfWork, IGetRoomByIdUseCase getRoomByIdUseCase, IFileStorageService _fileStorageService, IUpdateRoomUseCase updateRoomUseCase, ICreateNewRoomUseCase createNewRoomUseCase, IGetAllRoomsByMotelIdUseCase getRoomsByMotelIdUseCase, IGetRoomByRoomCodeAndIdMotelUseCase getRoomByRoomCodeAndIdMotelUseCase)
		{
			this.unitOfWork = unitOfWork;
			this.createNewRoomUseCase = createNewRoomUseCase;
			this.getRoomsByMotelIdUseCase = getRoomsByMotelIdUseCase;
			this.getRoomByRoomCodeAndIdMotelUseCase = getRoomByRoomCodeAndIdMotelUseCase;
			this._fileStorageService = _fileStorageService;
			this.updateRoomUseCase = updateRoomUseCase;
			this.getRoomByIdUseCase = getRoomByIdUseCase;
		}
		public async Task<ResultStatus> CreateNewRoomAsync(RoomManagerDTO roomDTO)
		{
			var getRoom = await getRoomByRoomCodeAndIdMotelUseCase.ExecuteAsync(roomDTO.RoomCode, roomDTO.IdMotel);
			if (getRoom == null)
			{
				var keyImage = await _fileStorageService.UploadImageAsync(roomDTO.ImageRoom);
				if (keyImage != null)
				{
					var room = new Room()
					{
						RoomCode = roomDTO.RoomCode,
						Description1 = roomDTO.Description1,
						KeyImageRoom = keyImage,
						Status = RoomStatus.Available,
						Description2 = roomDTO.Description2,
						Floor = roomDTO.Floor,
						Area = roomDTO.Area,
						Price = roomDTO.Price,
						IdMotel = roomDTO.IdMotel,
					};
					await createNewRoomUseCase.ExecuteAsync(room);
					var result = await unitOfWork.CommitAsync();
					if (result != 0)
					{
						return ResultStatus.Success;
					}
				}
			}

			return ResultStatus.Failure;
		}
		public async Task<IEnumerable<RoomManagerDTO>> GetAllRoomDTOsByMotelIdAsync(Guid id)
		{
			var listRoom = await getRoomsByMotelIdUseCase.ExecuteAsync(id);
			var rooms = new List<RoomManagerDTO>();
			foreach (var room in listRoom)
			{
				rooms.Add(new RoomManagerDTO()
				{
					Id = room.ID,
					RoomCode = room.RoomCode,
					Area = room.Area,
					Price = room.Price,
					IdMotel = room.IdMotel,
					Description1 = room.Description1,
					Description2 = room.Description2,
					Floor = room.Floor,
					Status = room.Status,
					UrlImageRoom = await _fileStorageService.GetPreSignedUrlAsync(room.KeyImageRoom)
				});
			}
			return rooms;
		}

		public Task<Room?> GetRoomByRoomCodeAndIdMotelAsync(string roomCode, Guid IdMotel)
		{
			return getRoomByRoomCodeAndIdMotelUseCase.ExecuteAsync(roomCode, IdMotel);
		}

		public Task<Room?> GetRoomByRoomIdAsync(int id)
		{
			return getRoomByIdUseCase.ExecuteAsync(id);
		}

		public async Task<ResultStatus> UpdateRoomAsync(RoomManagerDTO roomManagerDTO)
		{
			var getRoom = await getRoomByRoomCodeAndIdMotelUseCase.ExecuteAsync(roomManagerDTO.RoomCode, roomManagerDTO.IdMotel);
			if(getRoom == null)
			{
				var keyImage = await _fileStorageService.UploadImageAsync(roomManagerDTO.ImageRoom);
				var room = await GetRoomByRoomIdAsync(roomManagerDTO.Id);
				if (room != null)
				{
					if (keyImage != null)
					{
						room.KeyImageRoom = keyImage;
					}
					room.RoomCode = roomManagerDTO.RoomCode;
					room.Price = roomManagerDTO.Price;
					room.Area = roomManagerDTO.Area;
					room.Floor = roomManagerDTO.Floor;
					room.Description1 = roomManagerDTO.Description1;
					room.Description2 = roomManagerDTO.Description2;
					room.IdMotel = roomManagerDTO.IdMotel;
					updateRoomUseCase.Execute(room);
					var result = await unitOfWork.CommitAsync();
					if (result != 0)
					{
						return ResultStatus.Success;
					}
				}
			}
			return ResultStatus.Failure;
		}
	}
}
