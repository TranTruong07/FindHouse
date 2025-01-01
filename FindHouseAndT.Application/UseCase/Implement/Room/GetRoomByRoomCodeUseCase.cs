using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;

namespace FindHouseAndT.Application.UseCase
{
	public class GetRoomByRoomCodeUseCase : IGetRoomByRoomCodeUseCase
	{
		private readonly IRoomRepository roomRepository;

		public GetRoomByRoomCodeUseCase(IRoomRepository roomRepository)
		{
			this.roomRepository = roomRepository;
		}

		public Task<Room?> ExecuteAsync(string roomCode)
		{
			return roomRepository.GetRoomByIdAsync(roomCode);
		}
	}
}
