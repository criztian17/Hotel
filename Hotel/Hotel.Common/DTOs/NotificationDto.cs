using Hotel.Common.DTOs.Bases;
using Hotel.Common.DTOs.Bases.Interfaces;

namespace Hotel.Common.DTOs
{
    public class NotificationDto : BaseNotificationDto, IBaseDto
    {
        public int Id { get; set; }
    }
}
