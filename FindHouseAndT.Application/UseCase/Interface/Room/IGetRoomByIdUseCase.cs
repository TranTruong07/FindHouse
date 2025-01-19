using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public interface IGetRoomByIdUseCase
    {
        Task<Room?> ExecuteAsync(int id);
    }
}
