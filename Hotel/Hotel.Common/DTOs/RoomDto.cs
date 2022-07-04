using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Common.DTOs
{
    public class RoomDto : BaseDto
    {
        /// <summary>
        /// Number of the Room
        /// </summary>
        public string RoomNumber { get; set; }

        /// <summary>
        /// Indicates the current status of the Room
        /// </summary>
        public RoomStatus Status { get; set; }

        /// <summary>
        /// Booking Price
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal BookingPrice { get; set; }
    }
}
