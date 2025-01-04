using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IRoomRepository
    {
        Task CreateRoomAsync(Room room);
        void UpdateRoom(Room room);
        Task<List<Room>> GetAllRoomAsync();
        Task<Room?> GetRoomByRoomCodeAsync(string roomCode);
        Task<Room?> GetRoomByIdAsync(int Id);
        Task DeleteRoomAsync(Room room);
        Task<List<Room>> GetAllRoomsByMotelId(Guid motelId);
    }
}
