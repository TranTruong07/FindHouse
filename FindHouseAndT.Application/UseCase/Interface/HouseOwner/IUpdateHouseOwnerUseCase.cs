using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.UseCase.Interface.HouseOwner
{
    public interface IUpdateHouseOwnerUseCase
    {
        Task<bool> ExecuteAsync(FindHouseAndT.Models.Entities.HouseOwner houseOwner);
    }
}
