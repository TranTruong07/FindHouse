using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IMotelRepository
    {
        Task CreateMotelAsync(Motel motel);
        void UpdateMotel(Motel motel);
        Task<List<Motel>> GetAllMotelAsync();
        Motel? GetMotelById(Guid id);
        Task DeleteMotelAsync(Motel motel);
    }
}
