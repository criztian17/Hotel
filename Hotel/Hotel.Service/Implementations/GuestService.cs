using Hotel.Common.DTOs;
using Hotel.Common.Exceptions;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using Hotel.Service.Helpers;
using Hotel.Service.Helpers.Mappers;
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
        public async Task<GuestDto> CreateGuestAsync(GuestDto guest)
        {
            try
            {
                if (!ValidateModel(guest))
                {
                    throw new BusinessException(400, Constants.InvalidModel);
                }

                var result = await _guestRepository.CreateAsync(MapperGenericHelper<GuestDto, GuestEntity>.ToMapper(guest));
                return MapperGenericHelper<GuestEntity, GuestDto>.ToMapper(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteGuestAsync(GuestDto guest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistGuestByIdAsync(int id)
        {
            try
            {
                if (!await _guestRepository.ExistAsync(id))
                {
                    throw new BusinessException(400, String.Format(Constants.DoesNotExist,"guest",id));
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<GuestDto>> GetAllGuestsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<GuestBookingDto>> GetAllGuestsWithBookingAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GuestDto> GetGuestByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<GuestDto> GetGuestByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GuestBookingDto> GetGuestWithBookingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateGuestAsync(GuestDto guest)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        private bool ValidateModel(GuestDto guest)
        {
            if (string.IsNullOrEmpty(guest.Address) || string.IsNullOrEmpty(guest.Name) || string.IsNullOrEmpty(guest.PhoneNumber) || string.IsNullOrEmpty(guest.Email))
            { 
                return false;
            }
            return true;
        }
        #endregion
    }
}
