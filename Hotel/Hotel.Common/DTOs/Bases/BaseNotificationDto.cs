using Hotel.Common.Enumerators;

namespace Hotel.Common.DTOs.Bases
{
    public class BaseNotificationDto
    {
        /// <summary>
        /// Content of the notification
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Email to send the notification
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Status of the notification
        /// </summary>
        public NotificationStatus Status { get; set; }
    }
}
