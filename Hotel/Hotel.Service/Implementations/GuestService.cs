using Hotel.Common.DTOs;
using Hotel.Repository.Repositories.Interfaces;
using Hotel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Service.Implementations
{
    public class GuestService : IGuestService
    {
        #region Attributes
        private readonly IGuestRepository _guestRepository;
        #endregion

        #region Constructor
        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
        #endregion

        #region Public Methods
        public Task<GuestDto> CreateGuestAsync(GuestDto guest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGuestAsync(GuestDto guest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistGuestByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GuestDto>> GetAllGuestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GuestBookingDto>> GetAllGuestsWithBookingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GuestDto> GetGuestByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<GuestDto> GetGuestByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GuestBookingDto> GetGuestWithBookingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGuestAsync(GuestDto guest)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
