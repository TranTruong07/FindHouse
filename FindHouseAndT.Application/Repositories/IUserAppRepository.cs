using FindHouseAndT.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.Repositories
{
    public interface IUserAppRepository
    {
        Task CreateUserAppAsync(UserApp userApp);
        Task UpdateUserAppAsync(UserApp userApp);
        Task<IEnumerable<UserApp>> GetAllUserAppAsync();
        Task<UserApp?> GetUserAppByIdAsync(Guid id);
    }
}
