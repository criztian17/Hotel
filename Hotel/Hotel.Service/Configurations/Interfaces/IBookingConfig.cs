namespace Hotel.Service.Configurations.Interfaces
{
    /// <summary>
    /// Configuration to have a global logic variables for Booking
    /// </summary>
    public interface IBookingConfig
    {
        /// <summary>
        /// Max days in advance to book
        /// </summary>
        public int AdvanceDays { get; set; }

        /// <summary>
        /// Max days to book
        /// </summary>
        public int AllowedDays { get; set; }

    }
}
