
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public interface IRegisCustomerUseCase
    {
        Task ExecuteAsync(Customer customer);
    }
}
