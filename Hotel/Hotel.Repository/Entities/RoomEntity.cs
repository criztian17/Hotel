using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Repository.Entities
{
    public class RoomEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Number of the Room
        /// </summary>
        [Required]
        [MaxLength(5)]
        public string RoomNumber { get; set; }

        /// <summary>
        /// Indicates the current status of the Room
        /// </summary>
        [Required]
        public int Status { get; set; }

        /// <summary>
        /// Booking Price
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal BookingPrice { get; set; }

        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}
