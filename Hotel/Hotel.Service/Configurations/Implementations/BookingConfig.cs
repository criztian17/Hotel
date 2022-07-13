using Hotel.Service.Configurations.Interfaces;
using System;

namespace Hotel.Service.Configurations.Implementations
{
    public class BookingConfig : IBookingConfig
    {
        public int AdvanceDays { get; set; }
        public int AllowedDays { get; set; }
    }
}
