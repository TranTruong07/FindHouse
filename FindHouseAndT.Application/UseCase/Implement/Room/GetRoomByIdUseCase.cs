using FindHouseAndT.Application.Repositories;
using FindHouseAndT.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHouseAndT.Application.UseCase
{
    public class GetRoomByIdUseCase : IGetRoomByIdUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomByIdUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<Room?> ExecuteAsync(int id)
        {
            return _roomRepository.GetRoomByIdAsync(id);
        }
    }
}
