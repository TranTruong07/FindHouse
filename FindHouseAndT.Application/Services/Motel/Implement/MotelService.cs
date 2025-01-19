using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Application.ExternalInterface;
using FindHouseAndT.Application.UnitOfWork;
using FindHouseAndT.Application.UseCase;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.Services
{
    public class MotelService : IMotelService
    {
        private IUnitOfWork _unitOfWork;
        private IGetMotelByIdUseCase _getMotelByIdUseCase;
        private ICreateMotelUseCase _createMotelUseCase;
        private IGetAllMotelUseCase _getAllMotelUseCase;
        private IUpdateMotelUseCase _updateMotelUseCase;
        private IFileStorageService _fileStorageService;

        public MotelService(IFileStorageService fileStorageService, IUpdateMotelUseCase updateMotelUseCase, IUnitOfWork unitOfWork, IGetMotelByIdUseCase getMotelByIdUseCase, ICreateMotelUseCase createMotelUseCase, IGetAllMotelUseCase getAllMotelUseCase)
        {
            _unitOfWork = unitOfWork;
            _getMotelByIdUseCase = getMotelByIdUseCase;
            _createMotelUseCase = createMotelUseCase;
            _getAllMotelUseCase = getAllMotelUseCase;
            _updateMotelUseCase = updateMotelUseCase;
            _fileStorageService = fileStorageService;
        }

        public Motel? GetMotelById(Guid id)
        {
            return _getMotelByIdUseCase.Execute(id);
        }

        public async Task<ResultStatus> CreateMotelAsync(MotelManagerDTO motelDTO)
        {
			var keyImage = await _fileStorageService.UploadImageAsync(motelDTO.ImageFIle);
            if(keyImage != null)
            {
				Motel motel = new Motel()
				{
					Name = motelDTO.Name,
					Address = motelDTO.Address,
					Description1 = motelDTO.Description1,
					IdHouseOwner = motelDTO.IdHouseOwner,
					KeyImageMotel = keyImage,
					QuantityRoom = motelDTO.QuantityRoom,
					Description2 = motelDTO.Description2,
				};
				await _createMotelUseCase.ExecuteAsync(motel);
				var result = await _unitOfWork.CommitAsync();
				if (result != 0)
				{
					return ResultStatus.Success;
				}
			}
            return ResultStatus.Failure;
        }
        public async Task<List<MotelManagerDTO>> GetAllMotelAsync()
        {
            var motels = await _getAllMotelUseCase.ExecuteAsync();
            List<MotelManagerDTO> listMotel = new List<MotelManagerDTO>();
            foreach(var motel in motels)
            {
				listMotel.Add(new MotelManagerDTO()
				{
					IdMotel = motel.IdMotel,
					Address = motel.Address,
					Description1 = motel.Description1,
					Description2 = motel.Description2,
					Name = motel.Name,
					QuantityRoom = motel.QuantityRoom,
					ImageMotel = await _fileStorageService.GetPreSignedUrlAsync(motel.KeyImageMotel)
				});
			}
            return listMotel;
        }

        public async Task<ResultStatus> UpdateMotel(MotelManagerDTO motelDTO)
        {
            var motel = _getMotelByIdUseCase.Execute(motelDTO.IdMotel);
            if(motel != null)
            {
                var keyImg = await _fileStorageService.UploadImageAsync(motelDTO.ImageFIle);
                if(keyImg != null)
                {
                    motel.KeyImageMotel = keyImg;
                }
                motel.Description1 = motelDTO.Description1;
                motel.Description2 = motelDTO.Description2;
                motel.Name = motelDTO.Name;
                motel.Address = motelDTO.Address;
                motel.QuantityRoom = motelDTO.QuantityRoom;
                _updateMotelUseCase.Execute(motel);
                var result = await _unitOfWork.CommitAsync();
                if (result != 0)
                {
                    return ResultStatus.Success;
                }
            }
            return ResultStatus.Failure;
        }
	}
}
