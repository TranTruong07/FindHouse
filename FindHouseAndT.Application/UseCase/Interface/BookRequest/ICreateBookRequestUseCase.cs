using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public interface ICreateBookRequestUseCase
	{
		Task ExecuteAsync(BookRequest bookRequest);
	}
}
