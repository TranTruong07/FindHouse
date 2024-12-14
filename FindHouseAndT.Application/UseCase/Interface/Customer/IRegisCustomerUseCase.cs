
namespace FindHouseAndT.Application.UseCase.Interface.Customer
{
    public interface IRegisCustomerUseCase
    {
        Task<bool> ExecuteAsync(Models.Entities.Customer customer);
    }
}
