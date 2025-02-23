using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class UpdateRoomUseCase : IUpdateRoomUseCase
    {
        private readonly IRoomRepository roomRepository;

        public UpdateRoomUseCase(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public void Execute(Room room)
        {
            roomRepository.UpdateRoom(room);
        }
    }
}
