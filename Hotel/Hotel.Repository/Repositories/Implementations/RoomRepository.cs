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

        public async Task<ICollection<RoomEntity>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate)
        {
            try
            {

                var haveBooking = await _unitOfWork.DataContext.Bookings.AsNoTracking().Select(x => x).AnyAsync();

                if (haveBooking)
                {
                    var bookings = await _unitOfWork.DataContext.Bookings.AsNoTracking()
                        .Where(x => x.CheckIn >= startDate &&
                               x.CheckOut <= endDate &&
                               (x.Status == (int)BookingStatus.CheckOut || x.Status == (int)BookingStatus.Canceled) &&
                               DateTime.Now < startDate &&
                               DateTime.Now < endDate)
                        .Select(x => x.Id).ToListAsync();

                    List<RoomEntity> roomsWithoutBooking = await _unitOfWork.DataContext.Rooms.AsNoTracking()
                                    .Select(x => x)
                                    .Where(x => !bookings.Contains(x.Id) &&
                                           x.Status == (int)RoomStatus.Available &&
                                           DateTime.Now < startDate &&
                                    DateTime.Now < endDate).ToListAsync();

                    List<RoomEntity> roomsWithBooking = await _unitOfWork.DataContext.Rooms.AsNoTracking()
                                    .Select(x => x)
                                    .Where(x => bookings.Contains(x.Id) &&
                                           x.Status == (int)RoomStatus.Available &&
                                           DateTime.Now < startDate &&
                                    DateTime.Now < endDate).ToListAsync();

                    return roomsWithoutBooking.Union(roomsWithBooking).ToList();
                }

                return await _unitOfWork.DataContext.Rooms.AsNoTracking()
                    .Select(x => x).Where(x => x.Status == (int)RoomStatus.Available).ToListAsync();

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

        public async Task<bool> IsAvailableRoomAsync(int id, DateTime startDate, DateTime endDate)
        {
            try
            {
                var isAvailableRoom = await (from room in _unitOfWork.DataContext.Rooms.AsNoTracking()
                                             join bookings in _unitOfWork.DataContext.Bookings.AsNoTracking() on room.Id equals bookings.RoomId
                                             where
                                                bookings.RoomId == id &&
                                                (bookings.CheckIn >= startDate && bookings.CheckOut <= endDate) &&
                                                (bookings.Status == (int)BookingStatus.CheckIn || bookings.Status == (int)BookingStatus.Booked) &&
                                                room.Status == (int)RoomStatus.Available &&
                                                DateTime.Now < startDate &&
                                                DateTime.Now < endDate
                                             select room).FirstOrDefaultAsync();


                return isAvailableRoom == null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RoomEntity> GetRoomByRoomNumberAsync(string roomNumber)
        {
            try
            {
                return await _unitOfWork.DataContext.Rooms.AsNoTracking()
                                                    .Select(x => x)
                                                    .Where(x => x.RoomNumber == roomNumber)
                                                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DoesRoomHaveBookingsAsync(int id)
        {
            return await _unitOfWork.DataContext.Bookings.AsNoTracking().Where(x => x.RoomId == id).AnyAsync();
        }
        #endregion
    }
}
