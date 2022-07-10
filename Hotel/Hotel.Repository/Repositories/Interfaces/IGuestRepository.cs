using Hotel.Common.DTOs;
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
    }
}
