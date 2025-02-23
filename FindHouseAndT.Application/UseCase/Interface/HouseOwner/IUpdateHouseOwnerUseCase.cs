using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public interface IUpdateHouseOwnerUseCase
    {
        Task<bool> ExecuteAsync(HouseOwner houseOwner);
    }
}
