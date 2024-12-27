using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.Services
{
    public class MotelService
    {
        private IUnitOfWork _unitOfWork;
        private IGetMotelByIdUseCase _getMotelByIdUseCase;
        private ICreateMotelUseCase _createMotelUseCase;

        public MotelService(IUnitOfWork unitOfWork, IGetMotelByIdUseCase getMotelByIdUseCase, ICreateMotelUseCase createMotelUseCase)
        {
            _unitOfWork = unitOfWork;
            _getMotelByIdUseCase = getMotelByIdUseCase;
            _createMotelUseCase = createMotelUseCase;
        }

        public Motel? GetMotelById(Guid id)
        {
            return _getMotelByIdUseCase.ExecuteAsync(id);
        }

        public async Task<ResultStatus> CreateMotelAsync(Motel motel)
        {
            await _createMotelUseCase.ExecuteAsync(motel);
            var result = await _unitOfWork.CommitAsync();
            if(result != 0)
            {
                return ResultStatus.Success;
            }
            return ResultStatus.Failure;
        }
	}
}
