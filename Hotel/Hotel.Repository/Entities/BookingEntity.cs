using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Repository.Entities
{
    public class BookingEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set; }

        /// <summary>
        /// Number of the reservation
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string BookingNumber { get; set; }

        /// <summary>
        /// Booked Room
        /// </summary>
        public RoomEntity Room { get; set; }

        /// <summary>
        /// Guest who books the room
        /// </summary>
        public GuestEntity Guest { get; set; }

        /// <summary>
        /// Date when the Booking is created
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date when the Booking is updated
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Date when the Booking starts
        /// </summary>
        [Required]
        public DateTime CheckIn { get; set; }

        /// <summary>
        /// Date when the Booking ends
        /// </summary>
        [Required]
        public DateTime CheckOut { get; set; }

        /// <summary>
        /// Amount of the reservation
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Status of the booking
        /// </summary>
        [Required]
        public int Status { get; set; }
    }
}
