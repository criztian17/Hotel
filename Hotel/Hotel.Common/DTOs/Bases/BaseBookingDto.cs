using Hotel.Common.Enumerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Common.DTOs.Bases
{
    public  class BaseBookingDto
    {
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
        
    }
}
