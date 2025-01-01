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

        public RoomService(IUnitOfWork unitOfWork, ICreateNewRoomUseCase createNewRoomUseCase, IGetAllRoomsByMotelIdUseCase getRoomsByMotelIdUseCase, IGetRoomByRoomCodeUseCase getRoomByRoomCodeUseCase)
        {
            this.unitOfWork = unitOfWork;
            this.createNewRoomUseCase = createNewRoomUseCase;
            this.getRoomsByMotelIdUseCase = getRoomsByMotelIdUseCase;
            this.getRoomByRoomCodeUseCase = getRoomByRoomCodeUseCase;

		}
        public async Task<ResultStatus> CreateNewRoomAsync(Room room)
        {
            await createNewRoomUseCase.ExecuteAsync(room);
            var result = await unitOfWork.CommitAsync();
            if(result != 0)
            {
                return ResultStatus.Success;
            }
            return ResultStatus.Failure;
        }
        public async Task<IEnumerable<Room>> GetAllRoomsByMotelIdAsync(Guid id)
        {
            return await getRoomsByMotelIdUseCase.ExecuteAsync(id);
        }

        public async Task<Room?> GetRoomByRoomCodeAsync(string roomCode)
        {
            return await getRoomByRoomCodeUseCase.ExecuteAsync(roomCode);
        }
    }
}
