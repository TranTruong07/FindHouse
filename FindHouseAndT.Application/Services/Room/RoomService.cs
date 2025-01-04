using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.Services
{
    public class RoomService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICreateNewRoomUseCase createNewRoomUseCase;
        private readonly IGetAllRoomsByMotelIdUseCase getRoomsByMotelIdUseCase;
        private readonly IGetRoomByRoomCodeUseCase getRoomByRoomCodeUseCase;
        private readonly IUpdateRoomUseCase updateRoomUseCase;
        private readonly IGetRoomByIdUseCase getRoomByIdUseCase;
        private readonly AWSService aWSService;

        public RoomService(IUnitOfWork unitOfWork, IGetRoomByIdUseCase getRoomByIdUseCase, AWSService aWSService, IUpdateRoomUseCase updateRoomUseCase, ICreateNewRoomUseCase createNewRoomUseCase, IGetAllRoomsByMotelIdUseCase getRoomsByMotelIdUseCase, IGetRoomByRoomCodeUseCase getRoomByRoomCodeUseCase)
        {
            this.unitOfWork = unitOfWork;
            this.createNewRoomUseCase = createNewRoomUseCase;
            this.getRoomsByMotelIdUseCase = getRoomsByMotelIdUseCase;
            this.getRoomByRoomCodeUseCase = getRoomByRoomCodeUseCase;
            this.aWSService = aWSService;
            this.updateRoomUseCase = updateRoomUseCase;
            this.getRoomByIdUseCase = getRoomByIdUseCase;
		}
        public async Task<ResultStatus> CreateNewRoomAsync(RoomManagerDTO roomDTO)
        {
            var keyImage = await aWSService.UploadImageToAWSAsync(roomDTO.ImageRoom);
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
            return ResultStatus.Failure;
        }
        public async Task<IEnumerable<Room>> GetAllRoomsByMotelIdAsync(Guid id)
        {
            return await getRoomsByMotelIdUseCase.ExecuteAsync(id);
        }

        public Task<Room?> GetRoomByRoomCodeAsync(string roomCode)
        {
            return getRoomByRoomCodeUseCase.ExecuteAsync(roomCode);
        }

        public Task<Room?> GetRoomByRoomIdAsync(int id)
        {
            return getRoomByIdUseCase.ExecuteAsync(id);
        }

        public async Task<ResultStatus> UpdateRoomAsync(RoomManagerDTO roomManagerDTO)
        {
            var keyImage = await aWSService.UploadImageToAWSAsync(roomManagerDTO.ImageRoom);
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
            return ResultStatus.Failure;
        }   
    }
}
