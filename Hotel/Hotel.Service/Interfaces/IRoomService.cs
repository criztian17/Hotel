using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Service.Interfaces
{
    public interface IRoomService
    {
        /// <summary>
        /// Create a new room
        /// </summary>
        /// <param name="room">BaseRoomDto object</param>
        /// <returns>RoomDto object</returns>
        Task<RoomDto> CreateRoomAsync(BaseRoomDto room);

        /// <summary>
        /// Delete a room
        /// </summary>
        /// <param name="id">Room Id</param>
        /// <returns>Boolean</returns>
        Task<bool> DeleteRoomAsync(int id);

        /// <summary>
        /// Get all the rooms
        /// </summary>
        /// <returns>Collection of RoomDto</returns>
        Task<ICollection<RoomDto>> GetAllRoomsAsync();

        /// <summary>
        /// Get the room by Id
        /// </summary>
        /// <param name="id">Room Id</param>
        /// <returns>RoomDto object</returns>
        Task<RoomDto> GetRoomByIdAsync(int id);

        /// <summary>
        /// Update the room
        /// </summary>
        /// <param name="room">RoomDto object</param>
        /// <returns>Boolean</returns>
        Task<bool> UpdateRoomAsync(RoomDto room);

        /// <summary>
        /// Change the current status of the room
        /// </summary>
        /// <param name="id">Room Id</param>
        /// <param name="status">New status</param>
        /// <returns>Boolean</returns>
        Task<bool> ChangeRoomStatusAsync(int id, RoomStatus status);

        /// <summary>
        /// Check if the room is available to be booked
        /// </summary>
        /// <param name="id">Room Id</param>
        /// <param name="startDate">When the booking starts</param>
        /// <param name="endDate">When the booking ends</param>
        /// <returns>Boolean</returns>
        Task<bool> IsAvailableRoomAsync(int id, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Get the availables rooms
        /// </summary>
        /// <param name="startDate">Date from</param>
        /// <param name="endDate">Date end</param>
        /// <returns>Collection of RoomDto</returns>
        Task<ICollection<RoomDto>> GetAvailablesRoomsAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Get the room by room number
        /// </summary>
        /// <param name="roomNumber">Number of the room</param>
        /// <returns>RoomDto object</returns>
        Task<RoomDto> GetRoomByRoomNumberAsync(string roomNumber);
    }
}
