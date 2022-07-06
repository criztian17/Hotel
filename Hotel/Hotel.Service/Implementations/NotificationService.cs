using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Repository.Repositories.Interfaces;
using Hotel.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Hotel.Service.Implementations
{
    public class NotificationService : INotificationService
    {
        #region Attributes
        private readonly INotificationRepository _notificationRepository;
        #endregion

        #region Constructor
        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        #endregion

        #region Public Methods
        public Task<NotificationDto> CreateNotificationAsync(BaseNotificationDto notification)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
