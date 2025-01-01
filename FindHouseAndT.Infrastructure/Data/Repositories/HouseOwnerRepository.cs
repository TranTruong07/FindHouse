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
        public Task CreateHouseOwnerAsync(HouseOwner houseOwner)
        {
            _houseDbContext.HouseOwners.AddAsync(houseOwner);
            return Task.CompletedTask;
        }

        public Task<List<HouseOwner>> GetAllHouseOwnerAsync()
        {
            return _houseDbContext.HouseOwners.Include(x => x.UserApp).ToListAsync();
        }

        public Task<HouseOwner?> GetHouseOwnerByIdAsync(Guid id)
        {
            return _houseDbContext.HouseOwners.Include(x => x.UserApp).Where(x => x.IdHouseOwner.Equals(id)).FirstOrDefaultAsync();
        }

        public Task UpdateHouseOwnerAsync(HouseOwner houseOwner)
        {
            _houseDbContext.HouseOwners.Update(houseOwner);
            return Task.CompletedTask;
        }
    }
}
