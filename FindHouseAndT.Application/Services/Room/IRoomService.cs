using FindHouseAndT.Application.DTOs;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.Services
{
	public interface IRoomService
	{
		Task<ResultStatus> CreateNewRoomAsync(RoomManagerDTO roomDTO);
		Task<IEnumerable<RoomManagerDTO>> GetAllRoomDTOsByMotelIdAsync(Guid id);
		Task<Room?> GetRoomByRoomCodeAndIdMotelAsync(string roomCode, Guid IdMotel);
		Task<Room?> GetRoomByRoomIdAsync(int id);
		Task<ResultStatus> UpdateRoomAsync(RoomManagerDTO roomManagerDTO);
	}
}
