using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;

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
        #endregion
    }
}
