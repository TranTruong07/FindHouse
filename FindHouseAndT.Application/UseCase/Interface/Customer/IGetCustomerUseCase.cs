using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public interface IGetCustomerUseCase
    {
        Task<Customer?> ExecuteAsync(Guid customerId);
    }
}
