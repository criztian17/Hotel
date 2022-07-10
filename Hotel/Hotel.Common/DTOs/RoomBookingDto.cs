using Hotel.Common.DTOs.Bases;
using Hotel.Common.DTOs.Bases.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hotel.Common.DTOs
{
    public class RoomBookingDto : BaseRoomDto, IBaseDto
    {
        public int Id { get ; set ; }

        /// <summary>
        /// Reservations
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<FullBookingDto> Bookings { get; set; }
    }
}
