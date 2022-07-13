using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Service.Interfaces
{
    public interface IBookingService
    {
        /// <summary>
        /// Create a new booking
        /// </summary>
        /// <param name="booking">BookingDto object</param>
        /// <returns>BookingFullDto object</returns>
        Task<FullBookingDto> CreateBookingAsync(BookingDto booking);

        /// <summary>
        /// Get all the bookings
        /// </summary>
        /// <returns>Collection of BookingFullDto</returns>
        Task<ICollection<FullBookingDto>> GetAllBookingsAsync();

        /// <summary>
        /// Get the booking by Id
        /// </summary>
        /// <param name="id">Booking Id</param>
        /// <returns>BookingFullDto object</returns>
        Task<FullBookingDto> GetBookingByIdAsync(int id);

        /// <summary>
        /// Update the booking
        /// </summary>
        /// <param name="id">Booking Id</param>
        /// <param name="BaseBookingDto">updatedBbooking object</param>
        /// <returns>Boolean</returns>
        Task<bool> UpdateBookingAsync(int id, BaseBookingDto updatedBbooking);

        /// <summary>
        /// Change the status of the booking
        /// </summary>
        /// <param name="id">Booking Id</param>
        /// <param name="status">New Statust</param>
        /// <returns>bool</returns>
        Task<bool> ChanceBookingStatus(int id, BookingStatus status);

    }
}
