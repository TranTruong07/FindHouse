using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IHouseOwnerRepository
    {
        Task CreateHouseOwnerAsync(HouseOwner houseOwner);
        Task UpdateHouseOwnerAsync(HouseOwner houseOwner);
        Task<List<HouseOwner>> GetAllHouseOwnerAsync();
        Task<HouseOwner?> GetHouseOwnerByIdAsync(Guid id);
    }
}
