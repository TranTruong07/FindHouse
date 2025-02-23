using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IRoomRepository
    {
        Task CreateRoomAsync(Room room);
        void UpdateRoom(Room room);
        Task<List<Room>> GetAllRoomAsync();
        Task<Room?> GetRoomByRoomCodeAndIdMotelAsync(string roomCode, Guid motelId);
        Task<Room?> GetRoomByIdAsync(int roomId);
        Task DeleteRoomAsync(Room room);
        Task<List<Room>> GetAllRoomsByMotelId(Guid motelId);
    }
}
