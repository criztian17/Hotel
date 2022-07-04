using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Implementations
{
    public class NotificationRepository : BaseRepository<NotificationEntity>, INotificationRepository
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public NotificationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Public Methods
        public async Task<bool> ChangeNotificationStatusAsync(int id, NotificationStatus status)
        {
            try
            {
                var notification = await GetByIdAsync(id);
                notification.Status = (int)status;

                return await UpdateAsync(notification);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 
        #endregion
    }
}
