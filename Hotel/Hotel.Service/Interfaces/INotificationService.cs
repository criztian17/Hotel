using Hotel.Common.DTOs;
using System.Threading.Tasks;

namespace Hotel.Service.Interfaces
{
    public interface INotificationService
    {
        /// <summary>
        /// Create a new notification
        /// </summary>
        /// <param name="notification">NotificationDto object</param>
        /// <returns>NotificationDto object</returns>
        Task<NotificationDto> CreateNotificationAsync(NotificationDto notification);

    }
}
