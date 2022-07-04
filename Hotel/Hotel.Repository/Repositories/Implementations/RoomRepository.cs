using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Implementations
{
    public class RoomRepository : BaseRepository<RoomEntity>, IRoomRepository
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public RoomRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods

        public async Task<ICollection<RoomEntity>> GetAvailableRoomsAsync()
        {
            try
            {
                var availableRooms = await _unitOfWork.DataContext.Rooms.Select(x => x).Where(x => x.Status == (int)RoomStatus.Available).ToListAsync();

                if (!availableRooms.Any())
                {
                    return new List<RoomEntity>();
                }

                return availableRooms;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ChangeRoomStatusAsync(int id, RoomStatus status)
        {
            try
            {
                var room = await GetByIdAsync(id);
                room.Status = (int)status;

                return await UpdateAsync(room);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 
        #endregion
    }
}
