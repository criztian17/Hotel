using AutoMapper;
using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
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
    public class RoomService : IRoomService
    {
        #region Attributes
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        //private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            //_bookingService = bookingService;
        }
        #endregion

        #region Public Methods
        public async Task<bool> ChangeRoomStatusAsync(int id, RoomStatus status)
        {
            try
            {
                if (!await DoesRoomExistByIdAsync(id))
                    throw new BusinessException(400, string.Format(Constants.CommonMessages.NotExist, "room", id));

                return await _roomRepository.ChangeRoomStatusAsync(id, status);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomDto> CreateRoomAsync(BaseRoomDto room)
        {
            try
            {
                if (!ValidateModel(room))
                {
                    throw new BusinessException(400, Constants.CommonMessages.RequiredFields);
                }

                if (await DoesRoomtExistByNumberAsync(room.RoomNumber))
                    throw new BusinessException(400, string.Format(Constants.RoomMessages.RoomExist, "room number", room.RoomNumber));
                

                var result = await _roomRepository.CreateAsync(_mapper.Map<BaseRoomDto, RoomEntity>(room));

                return _mapper.Map<RoomEntity, RoomDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            try
            {
                if (!await DoesRoomExistByIdAsync(id))
                    throw new BusinessException(400, "Room cannot be deleted. " + string.Format(Constants.CommonMessages.NotExist, "room", id));

                //TODO: Pending validate if the room already has any booking
                if (true)
                {

                }

                var guest = await _roomRepository.GetByIdAsync(id);

                return await _roomRepository.DeleteAsync(guest);

            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public async Task<ICollection<RoomDto>> GetAllRoomsAsync()
        {
            try
            {
                var result = await _roomRepository.GetAll().ToListAsync();

                return _mapper.Map<List<RoomEntity>, ICollection<RoomDto>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomDto> GetRoomByIdAsync(int id)
        {
            try
            {
                if (!await DoesRoomExistByIdAsync(id))
                    throw new BusinessException(400, string.Format(Constants.CommonMessages.NotExist, "room", id));

                var guest = await _roomRepository.GetByIdAsync(id);

                return _mapper.Map<RoomEntity, RoomDto>(guest);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsAvailableRoomAsync(int id)
        {
            try
            {
                if (!await DoesRoomExistByIdAsync(id))
                    throw new BusinessException(400, string.Format(Constants.CommonMessages.NotExist, "room", id));

                return await _roomRepository.IsAvailableRoomAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateRoomAsync(RoomDto updatedRoom)
        {
            try
            {
                if (!await DoesRoomExistByIdAsync(updatedRoom.Id))
                    throw new BusinessException(400, "Room cannot be Updated. " + string.Format(Constants.CommonMessages.NotExist, "room", updatedRoom.Id));

                var currentRoom = await GetRoomByIdAsync(updatedRoom.Id);

                var differences = ComparisonHelper<RoomDto, RoomDto>.GetListOfDifferences(currentRoom, updatedRoom);

                if (!differences.Any())
                    throw new BusinessException(400, Constants.CommonMessages.NothingToUpdate);

                //Check if the room number changed
                var hasRoomChanged = differences.Keys.Where(x => x.ToLower().Equals("roomnumber")).Any();

                if (hasRoomChanged)
                {
                    if (await DoesRoomtExistByNumberAsync(updatedRoom.RoomNumber))
                    {
                        throw new BusinessException(400, string.Format(Constants.RoomMessages.RoomExist, "room number", updatedRoom.RoomNumber));
                    }
                }

                return await _roomRepository.UpdateAsync(_mapper.Map<RoomDto, RoomEntity>(updatedRoom));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<RoomDto>> GetAvailablesRoomsAsync()
        {
            try
            {
                var result = await _roomRepository.GetAvailableRoomsAsync();

                return _mapper.Map<List<RoomEntity>, ICollection<RoomDto>>((List<RoomEntity>)result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomDto> GetRoomByRoomNumberAsync(string roomNumber)
        {
            try
            {
                if (! await DoesRoomtExistByNumberAsync(roomNumber))
                {
                    throw new BusinessException(400, string.Format(Constants.RoomMessages.RoomDoesNotExist, roomNumber));
                }

                var room = await _roomRepository.GetRoomByRoomNumberAsync(roomNumber);

                return _mapper.Map<RoomEntity, RoomDto>(room);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods
        private bool ValidateModel(BaseRoomDto room)
        {
            return (string.IsNullOrEmpty(room.RoomNumber) ||
                    string.IsNullOrEmpty(room.Status.ToString()) ||
                    room.BookingPrice > 0);
        }

        private async Task<bool> DoesRoomExistByIdAsync(int id)
        {
            try
            {
                return await _roomRepository.ExistAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> DoesRoomtExistByNumberAsync(string roomNumber)
        {
            try
            {
                var guest = await _roomRepository.GetRoomByRoomNumberAsync(roomNumber);

                return guest != null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion
    }
}
