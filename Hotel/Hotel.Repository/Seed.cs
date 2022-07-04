using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Repository
{
    public class Seed
    {
        #region Attibutes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public Seed(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Fills the initial data to the system
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            if (!_unitOfWork.DataContext.Guests.Any())
            {
                var guests = new List<GuestEntity>
                {
                    new GuestEntity { Email = "cetofacyp@robot-mail.com", Address = "AV 1 with st 1" , Name = "Cristian Gutierrez" , PhoneNumber = "123654789"},
                    new GuestEntity { Email = "qudimiv@inboxbear.com", Address = "AV 2 with st 2" , Name = "Pepe Munoz" , PhoneNumber = "987456321"},
                    new GuestEntity { Email = "xesuci@getnada.com", Address = "AV 3 with st 3" , Name = "Juan Ramirez" , PhoneNumber = "147852369"},
                    new GuestEntity { Email = "hekek@getairmail.com", Address = "AV 4 with st 4" , Name = "Lucas Lopez" , PhoneNumber = "963258741"},
                };

                await _unitOfWork.DataContext.Guests.AddRangeAsync(guests);
                await _unitOfWork.CommitAsync();
            }

            if (!_unitOfWork.DataContext.Rooms.Any())
            {
                var rooms = new List<RoomEntity>
                {
                    new RoomEntity { BookingPrice = 150, Status = (int)RoomStatus.Reserved , RoomNumber = "101"},
                    new RoomEntity { BookingPrice = 250, Status = (int)RoomStatus.Reserved , RoomNumber = "202"},
                    new RoomEntity { BookingPrice = 350, Status = (int)RoomStatus.Reserved , RoomNumber = "303"},
                    new RoomEntity { BookingPrice = 450, Status = (int)RoomStatus.Available , RoomNumber = "404"}
                };

                await _unitOfWork.DataContext.Rooms.AddRangeAsync(rooms);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
