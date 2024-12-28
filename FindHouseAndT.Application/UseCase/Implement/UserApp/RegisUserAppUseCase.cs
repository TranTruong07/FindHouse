using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
    public class RegisUserAppUseCase : IRegisUserAppUseCase
    {
        private readonly IUserAppRepository _userAppRepository;

        public RegisUserAppUseCase(IUserAppRepository userAppRepository)
        {
            _userAppRepository = userAppRepository;
        }

        public async Task<bool> ExecuteAsync(UserApp userApp)
        {
            await _userAppRepository.CreateUserAppAsync(userApp);
            return true;
        }
    }
}
