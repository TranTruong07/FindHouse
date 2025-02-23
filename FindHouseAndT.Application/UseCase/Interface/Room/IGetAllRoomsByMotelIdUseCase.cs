using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public interface IGetAllRoomsByMotelIdUseCase
    {
        Task<IEnumerable<Room>> ExecuteAsync(Guid id);
    }
}
