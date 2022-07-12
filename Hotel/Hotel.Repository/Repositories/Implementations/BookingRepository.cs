using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using System;
using System.Linq;
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

        public int GenerateBookingNumber()
        {
            try
            {
                var bookingNumber = _unitOfWork.DataContext.Bookings.Any() ? _unitOfWork.DataContext.Bookings.Select(x => x.BookingNumber).Max() : 1;

                if (bookingNumber == 1)
                    return bookingNumber;

                return bookingNumber + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
