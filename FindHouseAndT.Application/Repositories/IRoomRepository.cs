using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IRoomRepository
    {
        Task CreateRoomAsync(Room room);
        Task UpdateRoomAsync(Room room);
        Task<List<Room>> GetAllRoomAsync();
        Task<Room?> GetRoomByIdAsync(string roomCode);
        Task DeleteRoomAsync(Room room);
        Task<List<Room>> GetAllRoomsByMotelId(Guid motelId);
    }
}
