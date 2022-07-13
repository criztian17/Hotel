using Hotel.Repository.Entities;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Interfaces
{
    public interface IGuestRepository: IBaseRepository<GuestEntity>
    {
        /// <summary>
        /// Get the guest by email
        /// </summary>
        /// <param name="email">Guest email</param>
        /// <returns>GuestEntity obkect</returns>
        Task<GuestEntity> GetGuestByEmailAsync(string email);

        /// <summary>
        /// Check if the user already has any booking
        /// </summary>
        /// <param name="id">Guest Id</param>
        /// <returns>bool</returns>
        Task<bool> DoesGuestHaveBookingsAsync(int id);
    }
}
