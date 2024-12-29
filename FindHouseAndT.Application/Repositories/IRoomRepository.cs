using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IRoomRepository
    {
        Task CreateRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task<IEnumerable<Room>> GetAllRoomAsync();
        Task<Room?> GetRoomByIdAsync(string roomCode);
        Task DeleteRoomAsync(Room room);
        Task<IEnumerable<Room>> GetAllRoomsByMotelId(Guid motelId);
    }
}
