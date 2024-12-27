using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class GetMotelByIdUseCase : IGetMotelByIdUseCase
    {
        private readonly IMotelRepository _repository;

        public GetMotelByIdUseCase(IMotelRepository repository)
        {
            _repository = repository;
        }

		public Motel? ExecuteAsync(Guid id)
		{
			return _repository.GetMotelByIdAsync(id);
		}

    }
}
