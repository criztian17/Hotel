using Hotel.Common.DTOs.Bases;

namespace Hotel.Common.DTOs
{
    public class BookingDto : BaseBookingDto
    {
        /// <summary>
        /// Id of the room
        /// </summary>
        public int RoomId { get; set; }
        
        /// <summary>
        /// Id of the guest
        /// </summary>
        public int GuestId { get; set; }
    }
}
