using Hotel.Common.DTOs.Bases;

namespace Hotel.Common.DTOs
{
    public class BookingFullDto : BaseBookingDto
    {
        /// <summary>
        /// Booked Room
        /// </summary>
        public RoomDto Room { get; set; }

        /// <summary>
        /// Guest who books the room
        /// </summary>
        public GuestDto Guest { get; set; }

    }
}
