namespace Hotel.Common.DTOs
{
    public class GuestDto : BaseDto
    {
        /// <summary>
        /// Name of the person who is booking
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Adrees of the person who is booking
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Email of the person who is booking
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// PhoneNumber of the person who is booking
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
