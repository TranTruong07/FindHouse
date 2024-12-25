using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public interface IUpdateCustomerUseCase
	{
		Task<bool> ExecuteAsync(Customer customer);
	}
}
