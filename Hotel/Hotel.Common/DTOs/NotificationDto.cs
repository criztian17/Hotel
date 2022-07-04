using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Common.DTOs
{
    public class NotificationDto : BaseDto
    {
        private DateTime createdDateAux;

        [JsonIgnore]
        public DateTime CreateDateAux
        {
            get { return createdDateAux; }
            set { createdDateAux = CreateDate = value; }
        }

        /// <summary>
        /// Date when the notification is created
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime CreateDate { get; private set; }

        /// <summary>
        /// Content of the notification
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Email to send the notification
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Status of the notification
        /// </summary>
        public NotificationStatus Status { get; set; }

    }
}
