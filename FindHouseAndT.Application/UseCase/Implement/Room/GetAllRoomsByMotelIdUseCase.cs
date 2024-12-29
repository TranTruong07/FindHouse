using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class GetAllRoomsByMotelIdUseCase : IGetAllRoomsByMotelIdUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsByMotelIdUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<IEnumerable<Room>> ExecuteAsync(Guid id)
        {
            return await _roomRepository.GetAllRoomsByMotelId(id);   
        }
    }
}
