using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly FindHouseDbContext _houseDbContext;
        public RoomRepository(FindHouseDbContext context)
        {
            _houseDbContext = context;
        }

        public async Task CreateRoomAsync(Room room)
        {
            await _houseDbContext.Rooms.AddAsync(room);
        }

        public Task DeleteRoomAsync(Room room)
        {
            _houseDbContext.Rooms.Remove(room);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Room>> GetAllRoomAsync()
        {
            return await _houseDbContext.Rooms.Include(x => x.Motel).ToListAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(Guid id)
        {
            return await _houseDbContext.Rooms.Where(x => x.IdRoom.Equals(id)).FirstOrDefaultAsync();
        }

        public Task UpdateRoomAsync(Room room)
        {
            _houseDbContext.Rooms.Update(room);
            return Task.CompletedTask;
        }
    }
}
