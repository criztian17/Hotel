using Hotel.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Service.Interfaces
{
    public interface IGuestService
    {
        /// <summary>
        /// Create a new guest
        /// </summary>
        /// <param name="guest">GuestDto object</param>
        /// <returns>GuestDto object</returns>
        Task<GuestDto> CreateGuestAsync(GuestDto guest);

        /// <summary>
        /// Delete a guest
        /// </summary>
        /// <param name="guest">GuestDto object</param>
        /// <returns>Boolean</returns>
        Task<bool> DeleteGuestAsync(GuestDto guest);

        /// <summary>
        /// Get all the guests
        /// </summary>
        /// <returns>Collection of GuestDto</returns>
        Task<ICollection<GuestDto>> GetAllGuestsAsync();

        /// <summary>
        /// Get all the guests with booking
        /// </summary>
        /// <returns>ICollection of GuestBookingDto</returns>
        Task<ICollection<GuestBookingDto>> GetAllGuestsWithBookingAsync();

        /// <summary>
        /// Get the guest by Id
        /// </summary>
        /// <param name="id">Guest Id</param>
        /// <returns>GuestDto object</returns>
        Task<GuestDto> GetGuestByIdAsync(int id);

        /// <summary>
        /// Get the guest by email
        /// </summary>
        /// <param name="email">Guest email</param>
        /// <returns>GuestDto object</returns>
        Task<GuestDto> GetGuestByEmailAsync(string email);

        /// <summary>
        /// Get the guest with booking by Id
        /// </summary>
        /// <param name="id">Guest Id</param>
        /// <returns>GuestBookingDto object</returns>
        Task<GuestBookingDto> GetGuestWithBookingByIdAsync(int id);

        /// <summary>
        /// Update the guest
        /// </summary>
        /// <param name="guest">GuestDto object</param>
        /// <returns>Boolean</returns>
        Task<bool> UpdateGuestAsync(GuestDto guest);

        /// <summary>
        /// Check if the guest exist
        /// </summary>
        /// <param name="id">Guest Id</param>
        /// <returns>Boolean</returns>
        Task<bool> ExistGuestByIdAsync(int id);
    }
}
