using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Interfaces
{
    public interface IRoomRepository: IBaseRepository<RoomEntity>
    {
        /// <summary>
        /// Collection of the available rooms
        /// </summary>
        /// <returns></returns>
        Task<ICollection<RoomEntity>> GetAvailableRoomsAsync();

        /// <summary>
        /// Change the status of the room
        /// </summary>
        /// <param name="id">Room Id</param>
        /// <param name="status">New Status</param>
        /// <returns>Boolean</returns>
        Task<bool> ChangeRoomStatusAsync(int id, RoomStatus status);
    }
}
