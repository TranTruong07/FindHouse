using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.UseCase.Interface.UserApp
{
    public interface IRegisUserAppUseCase
    {
        Task<bool> ExecuteAsync(Models.Entities.UserApp userApp);
    }
}
