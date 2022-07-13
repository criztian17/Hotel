using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Implementations
{
    public class GuestRepository : BaseRepository<GuestEntity>, IGuestRepository
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public GuestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GuestEntity> GetGuestByEmailAsync(string email)
        {
            try
            {
                return await _unitOfWork.DataContext.Guests.AsNoTracking()
                                            .Select(x => x)
                                            .Where(x => x.Email == email)
                                            .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DoesGuestHaveBookingsAsync(int id)
        {
            return await _unitOfWork.DataContext.Bookings.AsNoTracking().Where(x => x.GuestId == id).AnyAsync();
        }
        #endregion
    }
}
