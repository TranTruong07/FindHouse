
using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class UpdateMotelUseCase : IUpdateMotelUseCase
    {
        private readonly IMotelRepository _repository;

        public UpdateMotelUseCase(IMotelRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Motel motel)
        {
            _repository.UpdateMotel(motel);
        }
    }
}
