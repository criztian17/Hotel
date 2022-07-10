using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Exceptions;
using Hotel.Common.Helpers;
using Hotel.Common.Helpers.Mappers;
using Hotel.Repository.Entities;
using Hotel.Repository.Repositories.Interfaces;
using Hotel.Service.Helpers;
using Hotel.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Service.Implementations
{
    public class GuestService : IGuestService
    {
        #region Attributes
        private readonly IGuestRepository _guestRepository;
        //private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
            //_bookingService = bookingService;
        }
        #endregion

        #region Public Methods
        public async Task<GuestDto> CreateGuestAsync(BaseGuestDto guest)
        {
            try
            {
                if (!ValidateModel(guest))
                {
                    throw new BusinessException(400, Constants.CommonMessages.RequiredFields);
                }

                if (await DoesGuestExistByEmailAsync(guest.Email))
                {
                    throw new BusinessException(400, string.Format(Constants.GuestMessages.GuestExist, "email", guest.Email));
                }

                var result = await _guestRepository.CreateAsync(MapperGenericHelper<BaseGuestDto, GuestEntity>.ToMapper(guest));

                return MapperGenericHelper<GuestEntity, GuestDto>.ToMapper(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteGuestAsync(int id)
        {
            try
            {
                if (!await DoesGuestExistByIdAsync(id))
                    throw new BusinessException(400, "Guest cannot be deleted. " + string.Format(Constants.CommonMessages.NotExist, "guest", id));

                //TODO: Pending validate if the guest already has any booking
                if (true)
                {

                }

                var guest = await _guestRepository.GetByIdAsync(id);

                return await _guestRepository.DeleteAsync(guest);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<GuestDto>> GetAllGuestsAsync()
        {
            try
            {
                var result = await _guestRepository.GetAll().ToListAsync();

                return MapperGenericHelper<GuestEntity, GuestDto>.ToMapperList(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //TODO: Pending to add the implementation of this
        public async Task<ICollection<GuestBookingDto>> GetAllGuestsWithBookingAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GuestDto> GetGuestByEmailAsync(string email)
        {
            try
            {
                if (await DoesGuestExistByEmailAsync(email))
                {
                    throw new BusinessException(400, string.Format(Constants.GuestMessages.GuestDoesNotExist, email));
                }

                var guest = await _guestRepository.GetGuestByEmailAsync(email);

                return MapperGenericHelper<GuestEntity, GuestDto>.ToMapper(guest);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GuestDto> GetGuestByIdAsync(int id)
        {
            try
            {
                if (!await DoesGuestExistByIdAsync(id))
                    throw new BusinessException(400, string.Format(Constants.CommonMessages.NotExist, "guest", id));

                var guest = await _guestRepository.GetByIdAsync(id);

                return MapperGenericHelper<GuestEntity, GuestDto>.ToMapper(guest);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //TODO: Pending to add the implementation of this
        public async Task<GuestBookingDto> GetGuestWithBookingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateGuestAsync(GuestDto updatedGuest)
        {
            try
            {
                if (!await DoesGuestExistByIdAsync(updatedGuest.Id))
                    throw new BusinessException(400, "Guest cannot be Updated. " + string.Format(Constants.CommonMessages.NotExist, "guest", updatedGuest.Id));

                var currentGuest = await GetGuestByIdAsync(updatedGuest.Id);

                var differences = ComparisonHelper<GuestDto, GuestDto>.GetListOfDifferences(currentGuest, updatedGuest);

                if (!differences.Any())
                    throw new BusinessException(400, Constants.CommonMessages.NothingToUpdate);

                //Check if the email changed
                var hasEmailChanged = differences.Keys.Where(x => x.ToLower().Equals("email")).Any();
                
                if (hasEmailChanged)
                {
                    if (await DoesGuestExistByEmailAsync(updatedGuest.Email))
                    {
                        throw new BusinessException(400, string.Format(Constants.GuestMessages.GuestExist, "email", updatedGuest.Email));
                    }
                }

                return await _guestRepository.UpdateAsync(MapperGenericHelper<GuestDto,GuestEntity>.ToMapper(updatedGuest));
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        #endregion

        #region Private Methods
        private bool ValidateModel(BaseGuestDto guest)
        {
            return !(string.IsNullOrEmpty(guest.Address) ||
                    string.IsNullOrEmpty(guest.Name) ||
                    string.IsNullOrEmpty(guest.PhoneNumber) ||
                    string.IsNullOrEmpty(guest.Email));
        }

        private async Task<bool> DoesGuestExistByEmailAsync(string email)
        {
            try
            {
                var guest = await _guestRepository.GetGuestByEmailAsync(email);

                return guest != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> DoesGuestExistByIdAsync(int id)
        {
            try
            {
                return await _guestRepository.ExistAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
