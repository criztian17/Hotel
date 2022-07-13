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
        #endregion

        #region Constructor
        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
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

                if (await _roomRepository.DoesRoomHaveBookingsAsync(id))
                    throw new BusinessException(400, "Room cannot be deleted. " + string.Format(Constants.CommonMessages.HasRecords, "bookings"));

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

        public async Task<bool> IsAvailableRoomAsync(int id, DateTime startDate, DateTime endDate)
        {
            try
            {
                var room = await GetRoomByIdAsync(id);

                if (!CorrectDates(startDate, endDate))
                    throw new BusinessException(400, Constants.CommonMessages.IncorrectDates);

                var hasBooking = await _roomRepository.DoesRoomHaveBookingsAsync(id);

                if (!hasBooking && room.Status == (RoomStatus.Available) && DateTime.Now < startDate && DateTime.Now < endDate)
                    return true;

                if (!(room.Status == (RoomStatus.Available) && DateTime.Now < startDate && DateTime.Now < endDate))
                    throw new BusinessException(400, Constants.RoomMessages.NotAvailable);

                if (hasBooking)
                {
                    startDate = FixDate(startDate);
                    endDate = FixDate(endDate, false);

                    var result = await _roomRepository.IsAvailableRoomAsync(id, startDate, endDate);

                    return !result ? throw new BusinessException(400, Constants.RoomMessages.NotAvailable) : result;
                }

                throw new BusinessException(400, Constants.RoomMessages.NotAvailable);
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

        public async Task<ICollection<RoomDto>> GetAvailablesRoomsAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                startDate = FixDate(startDate);
                endDate = FixDate(endDate, false);

                var result = await _roomRepository.GetAvailableRoomsAsync(startDate, endDate);

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
                if (!await DoesRoomtExistByNumberAsync(roomNumber))
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

        private DateTime FixDate(DateTime date, bool isStartDate = true)
        {
            date = isStartDate ? Convert.ToDateTime(date.ToShortDateString()) : date;

            if (!isStartDate)
            {
                date = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            }
            return date;
        }


        private bool CorrectDates(DateTime startBookingDate, DateTime endBookingDate)
        {
            return (startBookingDate <= endBookingDate);
        }
        #endregion
    }
}
