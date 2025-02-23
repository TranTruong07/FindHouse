using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public interface IGetMotelByIdUseCase
    {
        Motel? Execute(Guid id);
    }
}
