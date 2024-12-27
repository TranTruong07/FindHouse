using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public class CreateMotelUseCase : ICreateMotelUseCase
	{
		private readonly IMotelRepository _repository;

		public CreateMotelUseCase(IMotelRepository repository)
		{
			_repository = repository;
		}
		public async Task ExecuteAsync(Motel motel)
		{
			await _repository.CreateMotelAsync(motel);
		}
	}
}
