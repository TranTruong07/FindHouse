using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.Services
{
    public class MotelService
    {
        private IUnitOfWork _unitOfWork;
        private IGetMotelByIdUseCase _getMotelByIdUseCase;

        public MotelService(IUnitOfWork unitOfWork, IGetMotelByIdUseCase getMotelByIdUseCase)
        {
            _unitOfWork = unitOfWork;
            _getMotelByIdUseCase = getMotelByIdUseCase;
        }

        public Motel? GetMotelById(Guid id)
        {
            return _getMotelByIdUseCase.GetMotelById(id);
        }
    }
}
