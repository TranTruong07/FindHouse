using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class CreateNewRoomUseCase : ICreateNewRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public CreateNewRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task ExecuteAsync(Room room)
        {
            await _roomRepository.CreateRoomAsync(room);
        }
    }
}
