using Hotel.Common.DTOs.Bases;
using Hotel.Common.DTOs.Bases.Interfaces;
using Hotel.Common.Enumerators;
using System;
using System.ComponentModel.DataAnnotations;

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

        /// <summary>
        /// Number of the reservation
        /// </summary>
        public int BookingNumber { get; set; }

        /// <summary>
        /// Date when the Booking is created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date when the Booking is updated
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Amount of the reservation
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Status of the booking
        /// </summary>
        public BookingStatus Status { get; set; }
    }
}
