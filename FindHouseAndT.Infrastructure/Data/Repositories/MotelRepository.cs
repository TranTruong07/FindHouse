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
        public async Task CreateMotelAsync(Motel motel)
        {
            await _houseDbContext.Motels.AddAsync(motel);
        }

        public Task DeleteMotelAsync(Motel motel)
        {
            _houseDbContext.Motels.Remove(motel);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Motel>> GetAllMotelAsync()
        {
            return await _houseDbContext.Motels.Include(x => x.HouseOwner).ToListAsync();
        }

        public async Task<Motel?> GetMotelByIdAsync(Guid id)
        {
            return await _houseDbContext.Motels.Include(x => x.HouseOwner).Where(x => x.IdMotel.Equals(id)).SingleOrDefaultAsync();
        }

        public Task UpdateMotelAsync(Motel motel)
        {
            _houseDbContext.Motels.Update(motel);
            return Task.CompletedTask;
        }
    }
}
