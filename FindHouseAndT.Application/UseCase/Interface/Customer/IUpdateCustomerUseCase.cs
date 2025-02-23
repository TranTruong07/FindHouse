using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public interface IUpdateCustomerUseCase
	{
		Task ExecuteAsync(Customer customer);
	}
}
