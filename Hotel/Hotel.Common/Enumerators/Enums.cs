using System.ComponentModel;

namespace Hotel.Common.Enumerators
{
    /// <summary>
    /// Contains the status of the Room
    /// </summary>
    public enum RoomStatus: short
    {
        [Description("Reserved")]
        Reserved = 0,

        [Description("Available")]
        Available = 1
    }

    /// <summary>
    /// Contains the status of the booking
    /// </summary>
    public enum BookingStatus: short
    { 
        [Description("Canceled")]
        Canceled = 0,

        [Description ("Booked")]
        Booked = 1,

        [Description ("CheckIn")]
        CheckIn = 2,

        [Description ("CheckOut")]
        CheckOut = 3
    }

    /// <summary>
    /// Contains the status of the notification
    /// </summary>
    public enum NotificationStatus : short
    { 
        [Description("Pending")]
        Pending= 0,

        [Description("Sent")]
        Sent = 1
    }
}
