using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Repositories
{
    public interface IContractRepository
    {
        Task CreateContractAsync(Contract contract);
        Task UpdateContractAsync(Contract contract);
        Task<List<Contract>> GetAllContractAsync();
        Task<Contract?> GetContractByIdAsync(Guid id);
    }
}
