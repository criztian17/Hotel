using Hotel.Common.DTOs.Bases;
using Hotel.Common.DTOs.Bases.Interfaces;

namespace Hotel.Common.DTOs
{
    public class FullBookingDto : BaseBookingDto, IBaseDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Booked Room
        /// </summary>
        public BaseRoomDto Room { get; set; }

        /// <summary>
        /// Guest who books the room
        /// </summary>
        public BaseGuestDto Guest { get; set; }
    }
}
