using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Interfaces
{
    public interface INotificationRepository: IBaseRepository<NotificationEntity>
    {
        /// <summary>
        /// Change the status of the notification
        /// </summary>
        /// <param name="id">Notification Id</param>
        /// <param name="status">New status</param>
        /// <returns>Boolean</returns>
        Task<bool> ChangeNotificationStatusAsync(int id, NotificationStatus status);
    }
}
