using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Interfaces
{
    public interface IBookingRepository : IBaseRepository<BookingEntity>
    {
        /// <summary>
        /// Change the status of the booking
        /// </summary>
        /// <param name="id">Booking Id</param>
        /// <param name="status">New Status</param>
        /// <returns>Boolean</returns>
        Task<bool> ChangeBookingStatusAsync(int id, BookingStatus status);
    }
}
