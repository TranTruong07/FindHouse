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

        public async Task<bool> ExecuteAsync(HouseOwner houseOwner)
        {
            await repository.CreateHouseOwnerAsync(houseOwner);
            return true;
        }
    }
}
