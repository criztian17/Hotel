using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using System.Threading.Tasks;

namespace Hotel.Service.Interfaces
{
    public interface INotificationService
    {
        /// <summary>
        /// Create a new notification
        /// </summary>
        /// <param name="notification">BaseNotificationDto object</param>
        /// <returns>NotificationDto object</returns>
        Task<NotificationDto> CreateNotificationAsync(BaseNotificationDto notification);

    }
}
