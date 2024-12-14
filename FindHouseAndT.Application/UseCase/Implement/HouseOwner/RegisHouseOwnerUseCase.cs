using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Application.UseCase.Interface.HouseOwner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.UseCase.Implement.HouseOwner
{
    public class RegisHouseOwnerUseCase : IRegisHouseOwnerUseCase
    {
        private readonly IHouseOwnerRepository repository;
        public RegisHouseOwnerUseCase(IHouseOwnerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> ExecuteAsync(Models.Entities.HouseOwner houseOwner)
        {
            await repository.CreateHouseOwnerAsync(houseOwner);
            return true;
        }
    }
}
