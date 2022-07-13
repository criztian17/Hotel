using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Interfaces
{
    public interface IRoomRepository: IBaseRepository<RoomEntity>
    {
        /// <summary>
        /// Collection of the available rooms
        /// </summary>
        /// <param name="startDate">Date from</param>
        /// <param name="endDate">Date end</param>
        /// <returns>ICollection of RoomEntity</returns>
        Task<ICollection<RoomEntity>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Change the status of the room
        /// </summary>
        /// <param name="id">Room Id</param>
        /// <param name="status">New Status</param>
        /// <returns>Boolean</returns>
        Task<bool> ChangeRoomStatusAsync(int id, RoomStatus status);

        /// <summary>
        /// Check if the current room is available
        ///<param name="id">Room id</param>
        ///<param name="startDate"/>When the booking starts</param>
        ///<param name="endDate">When the booking ends</param>
        /// </summary>
        /// <returns>Boolean</returns>
        Task<bool> IsAvailableRoomAsync(int id, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Get the room by room number
        /// </summary>
        /// <param name="roomNumber">Number of the room</param>
        /// <returns>RoomEntity object</returns>
        Task<RoomEntity> GetRoomByRoomNumberAsync(string roomNumber);

        /// <summary>
        /// Check if the room already has any booking
        /// </summary>
        /// <param name="id">Room Id</param>
        /// <returns>bool</returns>
        Task<bool> DoesRoomHaveBookingsAsync(int id);
    }
}
