using Hotel.Common.DTOs.Bases.Interfaces;
using Hotel.Common.Enumerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Common.DTOs.Bases
{
    public  class BaseBookingDto
    {
       
        /// <summary>
        /// Number of the reservation
        /// </summary>
        public string BookingNumber { get; set; }

        /// <summary>
        /// Date when the Booking starts
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime CheckIn { get; set; }

        /// <summary>
        /// Date when the Booking ends
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime CheckOut { get; set; }

        /// <summary>
        /// Amount of the reservation
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Status of the booking
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public BookingStatus Status { get; set; }
    }
}
