using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase.Interface.HouseOwner
{
    public interface IRegisHouseOwnerUseCase
    {
        Task<bool> ExecuteAsync(FindHouseAndT.Models.Entities.HouseOwner houseOwner);
    }
}
