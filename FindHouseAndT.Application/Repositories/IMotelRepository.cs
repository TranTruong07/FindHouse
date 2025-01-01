using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IMotelRepository
    {
        public Task CreateMotelAsync(Motel motel);
        public Task UpdateMotelAsync(Motel motel);
        public Task<List<Motel>> GetAllMotelAsync();
        public Motel? GetMotelById(Guid id);
        public Task DeleteMotelAsync(Motel motel);
    }
}
