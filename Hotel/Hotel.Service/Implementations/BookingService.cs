using Hotel.Common.DTOs;
using Hotel.Repository.Repositories.Interfaces;
using Hotel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Service.Implementations
{
    public class BookingService : IBookingService
    {

        #region Attributes
        private readonly IBookingRepository _bookingRepository;
        private readonly INotificationService _notificationService;
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;
        #endregion

        #region Constructor
        public BookingService(IBookingRepository bookingRepository, INotificationService notificationService, IGuestService guestService, IRoomService roomService)
        {
            _bookingRepository = bookingRepository;
            _notificationService = notificationService;
            _guestService = guestService;
            _roomService = roomService;
        }
        #endregion

        #region Public Methods
        public Task<FullBookingDto> CreateBookingAsync(BookingDto booking)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookingAsync(FullBookingDto booking)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistBookingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<FullBookingDto>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FullBookingDto> GetBookingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGuestAsync(FullBookingDto booking)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
