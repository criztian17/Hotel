using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Repository.Entities
{
    public class NotificationEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Date when the notification is created
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Content of the notification
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// Email to send the notification
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        /// <summary>
        /// Status of the notification
        /// </summary>
        [Required]
        public int Status { get; set; }
    }
}
