using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
    public class UserAppRepository : IUserAppRepository
    {
        public Task CreateUserAppAsync(UserApp userApp)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserApp>> GetAllUserAppAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserApp?> GetUserAppByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAppAsync(UserApp userApp)
        {
            throw new NotImplementedException();
        }
    }
}
