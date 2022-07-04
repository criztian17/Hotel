using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Repository.Entities
{
    public class GuestEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the person who is booking
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// Adrees of the person who is booking
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        /// <summary>
        /// Email of the person who is booking
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        /// <summary>
        /// PhoneNumber of the person who is booking
        /// </summary>
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}
