using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Infrastructure.Data.AppDbContext;

namespace FindHouseAndT.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; set; }
        public IHouseOwnerRepository HouseOwnerRepository { get; set; }
        public IMotelRepository MotelRepository { get; set; }
        public IContractRepository ContractRepository { get; set; }
        public IRoomRepository RoomRepository { get; set; }

        private FindHouseDbContext context;

        public UnitOfWork(ICustomerRepository customerRepository, IHouseOwnerRepository houseOwnerRepository, IMotelRepository motelRepository, IContractRepository contractRepository, IRoomRepository roomRepository, FindHouseDbContext context)
        {
            CustomerRepository = customerRepository;
            HouseOwnerRepository = houseOwnerRepository;
            MotelRepository = motelRepository;
			ContractRepository = contractRepository;
            RoomRepository = roomRepository;
            this.context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
