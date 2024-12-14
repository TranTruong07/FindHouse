using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
    public class HouseOwnerRepository : IHouseOwnerRepository
    {
        private readonly FindHouseDbContext _houseDbContext;
        public HouseOwnerRepository(FindHouseDbContext context)
        {
            _houseDbContext = context;
        }
        public async Task CreateHouseOwnerAsync(HouseOwner houseOwner)
        {
            await _houseDbContext.HouseOwners.AddAsync(houseOwner);
        }

        public async Task<IEnumerable<HouseOwner>> GetAllHouseOwnerAsync()
        {
            return await _houseDbContext.HouseOwners.Include(x => x.UserApp).ToListAsync();
        }

        public async Task<HouseOwner?> GetHouseOwnerByIdAsync(Guid id)
        {
            return await _houseDbContext.HouseOwners.Include(x => x.UserApp).Where(x => x.IdHouseOwner.Equals(id)).FirstOrDefaultAsync();
        }

        public Task UpdateHouseOwnerAsync(HouseOwner houseOwner)
        {
            _houseDbContext.HouseOwners.Update(houseOwner);
            return Task.CompletedTask;
        }
    }
}
