using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class RegisHouseOwnerUseCase : IRegisHouseOwnerUseCase
    {
        private readonly IHouseOwnerRepository repository;
        public RegisHouseOwnerUseCase(IHouseOwnerRepository repository)
        {
            this.repository = repository;
        }

        public Task ExecuteAsync(HouseOwner houseOwner)
        {
            repository.CreateHouseOwnerAsync(houseOwner);
            return Task.CompletedTask;
        }
    }
}
