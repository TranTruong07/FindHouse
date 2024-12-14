

namespace FindHouseAndT.Application.UseCase.Interface.HouseOwner
{
    public interface IRegisHouseOwnerUseCase
    {
        Task<bool> ExecuteAsync(Models.Entities.HouseOwner houseOwner);
    }
}
