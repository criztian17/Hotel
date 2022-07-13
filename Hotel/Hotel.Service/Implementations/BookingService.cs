using AutoMapper;
using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using Hotel.Common.Exceptions;
using Hotel.Common.Helpers;
using Hotel.Common.Helpers.Mappers;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using Hotel.Service.Configurations.Interfaces;
using Hotel.Service.Helpers;
using Hotel.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IBookingConfig _bookingConfig;
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
            IMapper mapper,
            IBookingConfig bookingConfig
        )
        {
            _bookingRepository = bookingRepository;
            _notificationService = notificationService;
            _guestService = guestService;
            _roomService = roomService;
            _mapper = mapper;
            _bookingConfig = bookingConfig;
        }
        #endregion

        #region Public Methods
        public async Task<FullBookingDto> CreateBookingAsync(BookingDto booking)
        {
            try
            {
                var fullBooking = MapperGenericHelper<BookingDto, FullBookingDto>.ToMapper(booking);

                BaseCheckConditions(booking.CheckIn, booking.CheckOut);

                var guest = await _guestService.GetGuestByIdAsync(booking.GuestId);
                var room = await _roomService.GetRoomByIdAsync(booking.RoomId);
                
                fullBooking.BookingNumber = GenerateBookingNumber();

                fullBooking.CreatedDate = DateTime.UtcNow;

                fullBooking.GuestId = guest.Id;

                fullBooking.RoomId = room.Id;

                var totalDays = CalculateDays(booking.CheckIn, booking.CheckOut);

                fullBooking.Amount = CalculateAmoun(room.BookingPrice, totalDays);

                fullBooking.Status = BookingStatus.Booked;

                await _roomService.IsAvailableRoomAsync(booking.RoomId, booking.CheckIn, booking.CheckOut);

                var entity = await _bookingRepository.CreateAsync(_mapper.Map<FullBookingDto, BookingEntity>(fullBooking));

                //todo create notification
                return _mapper.Map<BookingEntity, FullBookingDto>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<FullBookingDto>> GetAllBookingsAsync()
        {
            try
            {
                var result = await _bookingRepository.GetAll().ToListAsync();

                return _mapper.Map<List<BookingEntity>, ICollection<FullBookingDto>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FullBookingDto> GetBookingByIdAsync(int id)
        {
            try
            {
                if (!await DoesBookingExistAsync(id))
                    throw new BusinessException(400, string.Format(Constants.CommonMessages.NotExist, "booking", id));

                var entity = await _bookingRepository.GetByIdAsync(id);

                return _mapper.Map<BookingEntity, FullBookingDto>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateBookingAsync(int id, BaseBookingDto updatedBbooking)
        {
            try
            {
                var currentBooking = await GetBookingByIdAsync(id);
                var updatedBookingAux = await GetBookingByIdAsync(id);

                updatedBookingAux.CheckIn = updatedBbooking.CheckIn;
                updatedBookingAux.CheckOut = updatedBbooking.CheckOut;

                var differences = ComparisonHelper<FullBookingDto, FullBookingDto>.GetListOfDifferences(currentBooking, updatedBookingAux);

                if (!differences.Any())
                    throw new BusinessException(400, Constants.CommonMessages.NothingToUpdate);

                BaseCheckConditions(updatedBbooking.CheckIn, updatedBbooking.CheckOut);

                var totalDays = CalculateDays(updatedBbooking.CheckIn, updatedBbooking.CheckOut);

                var room = await _roomService.GetRoomByIdAsync(currentBooking.RoomId);

                updatedBookingAux.Amount = CalculateAmoun(room.BookingPrice, totalDays);

                await _roomService.IsAvailableRoomAsync(room.Id, updatedBbooking.CheckIn, updatedBbooking.CheckOut);

                return await _bookingRepository.UpdateAsync(_mapper.Map<FullBookingDto, BookingEntity>(updatedBookingAux));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ChanceBookingStatus(int id, BookingStatus status)
        {
            try
            {
                var booking = await GetBookingByIdAsync(id);

                //if the current status is CheckIn or booked the user can update the booking status
                switch (booking.Status)
                {
                    case BookingStatus.CheckIn:
                    case BookingStatus.Booked:
                        booking.Status = status;
                        return await _bookingRepository.UpdateAsync(_mapper.Map<FullBookingDto, BookingEntity>(booking));
                    default:
                        throw new BusinessException(400, string.Format(Constants.BookingMessages.CannotChangeStatus, booking.Status.ToString()));
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Private Methods

        private void BaseCheckConditions(DateTime checkIn, DateTime checkOut)
        {
            advanceDays = _bookingConfig.AdvanceDays;
            allowedDays = _bookingConfig.AllowedDays;

            if (!IsCurrentDayEqualOrGreater(checkIn))
                throw new BusinessException(400, Constants.BookingMessages.CurrentDayEqualGreater);

            if (!IsAvailableDateToBooking(checkIn))
                throw new BusinessException(400, string.Format(Constants.BookingMessages.AdvanceDays, advanceDays));

            if (!CorrectDates(checkIn, checkOut))
                throw new BusinessException(400, Constants.CommonMessages.IncorrectDates);

            if (!AreDaysAllowedToBook(checkIn, checkOut))
                throw new BusinessException(400, string.Format(Constants.BookingMessages.AllowedDays, allowedDays));
        }

        public bool IsCurrentDayEqualOrGreater(DateTime startBookingDate)
        {
            return startBookingDate.Day > DateTime.Now.Day;
        }

        private bool IsAvailableDateToBooking(DateTime startBookingDate)
        {
            var advanceDaysToBook = (startBookingDate - DateTime.Now).TotalDays;
            return advanceDaysToBook <= advanceDays;
        }

        private bool AreDaysAllowedToBook(DateTime startBookingDate, DateTime endBookingDate)
        {
            return allowedDays >= CalculateDays(startBookingDate, endBookingDate);
        }

        private bool CorrectDates(DateTime startBookingDate, DateTime endBookingDate)
        {
            return (startBookingDate <= endBookingDate);
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

        private async Task<bool> DoesBookingExistAsync(int bookingId)
        { 
            return await _bookingRepository.ExistAsync(bookingId);
        }
        
        #endregion
    }
}
