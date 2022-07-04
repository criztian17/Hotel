using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hotel.Common.DTOs
{
    public class GuestBookingDto: GuestDto
    {
        /// <summary>
        /// Reservations
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<BookingDto> Bookings { get; set; }
    }
}
