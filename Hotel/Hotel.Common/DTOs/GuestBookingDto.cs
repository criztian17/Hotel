using Hotel.Common.DTOs.Bases;
using Hotel.Common.DTOs.Bases.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hotel.Common.DTOs
{
    public class GuestBookingDto: BaseGuestDto, IBaseDto
    {
        /// <summary>
        /// Reservations
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<FullBookingDto> Bookings { get; set; }
        
        public int Id { get; set; }
    }
}
