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

        public RoomService(IUnitOfWork unitOfWork, ICreateNewRoomUseCase createNewRoomUseCase)
        {
            this.unitOfWork = unitOfWork;
            this.createNewRoomUseCase = createNewRoomUseCase;
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
    }
}
