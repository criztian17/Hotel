using AutoMapper;
using Hotel.Common.DTOs;
using Hotel.Common.Enumerators;
using Hotel.Common.Exceptions;
using Hotel.Common.Helpers.Mappers;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using Hotel.Service.Helpers;
using Hotel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private readonly IMapper _mapper;
        #endregion

        #region Variables
        private static int advanceDays = 0;
        private static int allowedDays = 0; 
        #endregion

        #region Constructor
        public BookingService
        (
            IBookingRepository bookingRepository,
            INotificationService notificationService,
            IGuestService guestService,
            IRoomService roomService,
            IMapper mapper
        )
        {
            _bookingRepository = bookingRepository;
            _notificationService = notificationService;
            _guestService = guestService;
            _roomService = roomService;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        public async Task<FullBookingDto> CreateBookingAsync(BookingDto booking)
        {
            try
            {
                var fullBooking = MapperGenericHelper<BookingDto, FullBookingDto>.ToMapper(booking);

                CheckConditions(booking);

                fullBooking.BookingNumber = GenerateBookingNumber();

                fullBooking.CreatedDate = DateTime.UtcNow;

                fullBooking.Guest = await _guestService.GetGuestByIdAsync(booking.GuestId);

                fullBooking.Room = await _roomService.GetRoomByIdAsync(booking.RoomId);

                var totalDays = CalculateDays(booking.CheckIn, booking.CheckOut);

                fullBooking.Amount = CalculateAmoun(fullBooking.Room.BookingPrice, totalDays);

                fullBooking.Status = BookingStatus.Booked;

                await _roomService.IsAvailableRoomAsync(booking.RoomId);

                var result = await _bookingRepository.CreateAsync(_mapper.Map<FullBookingDto, BookingEntity>(fullBooking));

                await _roomService.ChangeRoomStatusAsync(booking.RoomId, RoomStatus.Reserved);

                //todo create notification

                return _mapper.Map<BookingEntity, FullBookingDto>(result);

            }
            catch (Exception)
            {
                throw;
            }
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

        #region Private Methods

        private void CheckConditions(BookingDto booking)
        {
            advanceDays = Convert.ToInt32(ConfigurationManager.AppSettings["AdvanceDays"]);
            allowedDays = Convert.ToInt32(ConfigurationManager.AppSettings["MaxDaysToBook"]);

            if (!IsAvailableDateToBooking(booking.CheckIn))
                throw new BusinessException(400, string.Format(Constants.BookingMessages.AdvanceDays, advanceDays));

            if (!CorrectDates(booking.CheckIn, booking.CheckOut))
                throw new BusinessException(400, Constants.BookingMessages.IncorrectDates);

            if (!AreDaysAllowedToBook(booking.CheckIn, booking.CheckOut))
                throw new BusinessException(400, string.Format(Constants.BookingMessages.AllowedDays, allowedDays));

        }

        private bool IsAvailableDateToBooking(DateTime startBookingDate)
        {
            var advanceDaysToBook = (startBookingDate.ToUniversalTime() - DateTime.UtcNow).TotalDays;
            return advanceDaysToBook <= advanceDays && startBookingDate.ToUniversalTime() >= DateTime.UtcNow;
        }

        private bool AreDaysAllowedToBook(DateTime startBookingDate, DateTime endBookingDate)
        {
            return allowedDays >= CalculateDays(startBookingDate, endBookingDate);
        }

        private bool CorrectDates(DateTime startBookingDate, DateTime endBookingDate)
        {
            return (startBookingDate >= endBookingDate);
        }

        private int CalculateDays(DateTime startBookingDate, DateTime endBookingDate)
        {
            return (endBookingDate.Day - startBookingDate.Day) + 1;
        }

        private decimal CalculateAmoun(decimal bookingPrice, int totalDays)
        {
            return bookingPrice * (decimal)totalDays;
        }

        private int GenerateBookingNumber()
        {
            return _bookingRepository.GenerateBookingNumber();
        }
        #endregion
    }
}
