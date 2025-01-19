using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public class GetRoomByRoomCodeAndIdMotelUseCase : IGetRoomByRoomCodeAndIdMotelUseCase
	{
		private readonly IRoomRepository roomRepository;

		public GetRoomByRoomCodeAndIdMotelUseCase(IRoomRepository roomRepository)
		{
			this.roomRepository = roomRepository;
		}

		public Task<Room?> ExecuteAsync(string roomCode, Guid IdMotel)
		{
			return roomRepository.GetRoomByRoomCodeAndIdMotelAsync(roomCode, IdMotel);
		}
	}
}
