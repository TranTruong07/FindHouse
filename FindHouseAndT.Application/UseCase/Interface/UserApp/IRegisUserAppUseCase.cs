using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public interface IRegisUserAppUseCase
    {
        Task<bool> ExecuteAsync(UserApp userApp);
    }
}
