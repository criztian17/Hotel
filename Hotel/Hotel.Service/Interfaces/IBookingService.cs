using Hotel.Common;
using Hotel.Common.DTOs;
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
        Task<BookingFullDto> CreateBookingAsync(BookingDto booking);

        /// <summary>
        /// Delete a booking
        /// </summary>
        /// <param name="booking">RoomDto object</param>
        /// <returns>Boolean</returns>
        Task<bool> DeleteBookingAsync(BookingFullDto booking);
        
        /// <summary>
        /// Get all the bookings
        /// </summary>
        /// <returns>Collection of BookingFullDto</returns>
        Task<ICollection<BookingFullDto>> GetAllBookingsAsync();

        /// <summary>
        /// Get the booking by Id
        /// </summary>
        /// <param name="id">Booking Id</param>
        /// <returns>BookingFullDto object</returns>
        Task<BookingFullDto> GetBookingByIdAsync(int id);

        /// <summary>
        /// Update the booking
        /// </summary>
        /// <param name="booking">BookingFullDto object</param>
        /// <returns>Boolean</returns>
        Task<bool> UpdateGuestAsync(BookingFullDto booking);

        /// <summary>
        /// Check if the booking exist
        /// </summary>
        /// <param name="id">Booking Id</param>
        /// <returns>Boolean</returns>
        Task<bool> ExistBookingByIdAsync(int id);

    }
}
