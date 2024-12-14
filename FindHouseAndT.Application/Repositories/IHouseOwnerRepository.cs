using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IHouseOwnerRepository
    {
        public Task CreateHouseOwnerAsync(HouseOwner houseOwner);
        public Task UpdateHouseOwnerAsync(HouseOwner houseOwner);
        public Task<IEnumerable<HouseOwner>> GetAllHouseOwnerAsync();
        public Task<HouseOwner?> GetHouseOwnerByIdAsync(Guid id);
    }
}
