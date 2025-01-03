using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
    public class MotelRepository : IMotelRepository
    {
        private readonly FindHouseDbContext _houseDbContext;
        public MotelRepository(FindHouseDbContext context)
        {
            _houseDbContext = context;
        }
        public Task CreateMotelAsync(Motel motel)
        {
            _houseDbContext.Motels.AddAsync(motel);
            return Task.CompletedTask;
        }

        public Task DeleteMotelAsync(Motel motel)
        {
            _houseDbContext.Motels.Remove(motel);
            return Task.CompletedTask;
        }

        public Task<List<Motel>> GetAllMotelAsync()
        {
            return _houseDbContext.Motels.Include(x => x.HouseOwner).ToListAsync();
        }

        public Motel? GetMotelById(Guid id)
        {
            return _houseDbContext.Motels.Include(x => x.HouseOwner).Where(x => x.IdMotel.Equals(id)).Include(x => x.Rooms).FirstOrDefault();
        }

        public void UpdateMotel(Motel motel)
        {
            _houseDbContext.Motels.Update(motel);
        }
    }
}
