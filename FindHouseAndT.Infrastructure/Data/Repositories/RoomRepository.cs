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

        public Task CreateRoomAsync(Room room)
        {
            _houseDbContext.Rooms.AddAsync(room);
            return Task.CompletedTask;
        }

        public Task DeleteRoomAsync(Room room)
        {
            _houseDbContext.Rooms.Remove(room);
            return Task.CompletedTask;
        }

        public Task<List<Room>> GetAllRoomAsync()
        {
            return _houseDbContext.Rooms.Include(x => x.Motel).ToListAsync();
        }

        public Task<List<Room>> GetAllRoomsByMotelId(Guid motelId)
        {
            return _houseDbContext.Rooms.Where(x => x.IdMotel.Equals(motelId)).Include(x => x.Motel).ToListAsync();
        }

        public Task<Room?> GetRoomByIdAsync(int Id)
        {
            return _houseDbContext.Rooms.Where(x => x.ID == Id).FirstOrDefaultAsync();
        }

        public  Task<Room?> GetRoomByRoomCodeAsync(string roomCode)
        {
            return _houseDbContext.Rooms.Where(x => x.RoomCode.Equals(roomCode)).FirstOrDefaultAsync();
        }

        public void UpdateRoom(Room room)
        {
            _houseDbContext.Rooms.Update(room);
        }
    }
}
