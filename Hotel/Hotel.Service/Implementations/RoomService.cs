using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using Hotel.Repository.Repositories.Interfaces;
using Hotel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Service.Implementations
{
    public class RoomService : IRoomService
    {
        #region Attributes
        private readonly IRoomRepository _roomRepository;
        #endregion

        #region Constructor
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        #endregion

        #region Public Methods
        public Task<bool> ChangeRoomStatusAsync(int id, RoomStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<RoomDto> CreateRoomAsync(BaseRoomDto room)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoomAsync(RoomDto room)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RoomDto>> GetAllRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomDto> GetRoomByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAvailableAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRoomAsync(RoomDto room)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
