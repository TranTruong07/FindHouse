using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IRoomRepository
    {
        public Task CreateRoomAsync(Room room);
        public Task UpdateRoomAsync(Room room);
        public Task<IEnumerable<Room>> GetAllRoomAsync();
        public Task<Room?> GetRoomByIdAsync(Guid id);
        public Task DeleteRoomAsync(Room room);
    }
}
