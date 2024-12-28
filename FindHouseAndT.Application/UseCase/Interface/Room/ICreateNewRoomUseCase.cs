using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public interface ICreateNewRoomUseCase
    {
        Task ExecuteAsync(Room room);
    }
}
