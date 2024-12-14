using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IMotelRepository
    {
        public Task CreateMotelAsync(Motel motel);
        public Task UpdateMotelAsync(Motel motel);
        public Task<IEnumerable<Motel>> GetAllMotelAsync();
        public Motel? GetMotelByIdAsync(Guid id);
        public Task DeleteMotelAsync(Motel motel);
    }
}
