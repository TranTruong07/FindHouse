using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly FindHouseDbContext _houseDbContext;
        public ContractRepository(FindHouseDbContext context)
        {
            _houseDbContext = context;
        }
        public Task CreateContractAsync(Contract contract)
        {
            _houseDbContext.Contracts.AddAsync(contract);
            return Task.CompletedTask;
        }

        public Task<List<Contract>> GetAllContractAsync()
        {
            return _houseDbContext.Contracts.Include(x => x.Customer).Include(x => x.Room).ToListAsync();
        }

        public Task<Contract?> GetContractByIdAsync(Guid id)
        {
            return _houseDbContext.Contracts.Include(x => x.Customer).Include(x => x.Room).FirstOrDefaultAsync(x => x.ContractId.Equals(id));
        }

        public Task UpdateContractAsync(Contract contract)
        {
            _houseDbContext.Contracts.Update(contract);
            return Task.CompletedTask;
        }
    }
}
