using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<BookingEntity>, IBookingRepository
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Constructor
        public BookingRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Methods
        public async Task<bool> ChangeBookingStatusAsync(int id, BookingStatus status)
        {
            try
            {
                var booking = await GetByIdAsync(id);
                booking.Status = (int)status;

                return await UpdateAsync(booking);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
