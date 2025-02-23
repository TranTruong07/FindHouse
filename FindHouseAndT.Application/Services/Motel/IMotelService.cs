using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;

namespace FindHouseAndT.Application.Services
{
	public interface IMotelService
	{
		Motel? GetMotelById(Guid id);
		Task<ResultStatus> CreateMotelAsync(MotelManagerDTO motelDTO);
		Task<List<MotelManagerDTO>> GetAllMotelAsync();
		Task<ResultStatus> UpdateMotel(MotelManagerDTO motelDTO);
	}
}
