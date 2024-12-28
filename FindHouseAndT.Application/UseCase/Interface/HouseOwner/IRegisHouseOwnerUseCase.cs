

namespace FindHouseAndT.Application.UseCase
{
    public interface IRegisHouseOwnerUseCase
    {
        Task<bool> ExecuteAsync(Models.Entities.HouseOwner houseOwner);
    }
}
