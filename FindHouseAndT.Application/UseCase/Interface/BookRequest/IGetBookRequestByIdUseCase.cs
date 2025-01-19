using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public interface IGetBookRequestByIdUseCase
	{
		Task<BookRequest?> ExecuteAsync(int id);
	}
}
