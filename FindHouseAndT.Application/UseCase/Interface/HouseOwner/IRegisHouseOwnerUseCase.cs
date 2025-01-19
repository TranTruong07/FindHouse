

namespace FindHouseAndT.Application.UseCase
{
    public interface IRegisHouseOwnerUseCase
    {
        Task ExecuteAsync(Models.Entities.HouseOwner houseOwner);
    }
}
