using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Infrastructure.Data.Repositories
{
    public class UserAppRepository : IUserAppRepository
    {
        public Task CreateUserAppAsync(UserApp userApp)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserApp>> GetAllUserAppAsync()
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
