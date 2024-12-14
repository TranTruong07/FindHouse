using FindHouseAndT.Application.Repositories;

namespace FindHouseAndT.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; set; }
        IHouseOwnerRepository HouseOwnerRepository { get; set; }
        IMotelRepository MotelRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        IRoomRepository RoomRepository { get; set; }
        IUserAppRepository UserAppRepository { get; set; }
        Task<int> CommitAsync();
    }
}
