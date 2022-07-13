using Hotel.Api.Helpers;
using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using Hotel.Common.Exceptions;
using Hotel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        #region Attributes
        private readonly IRoomService _roomService;
        #endregion

        #region Constructor
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        #endregion

        #region Actions

        [HttpPost]
        [Route("CreateRoomAsync")]
        [SwaggerOperation("Create room")]
        [SwaggerResponse(200, type: typeof(RoomDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<RoomDto>> CreateRoomAsync([FromBody] BaseRoomDto room)
        {
            try
            {
                return new JsonResult(await _roomService.CreateRoomAsync(room));
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }

        [HttpGet]
        [Route("GetAllRoomsAsync")]
        [SwaggerOperation("Get all rooms")]
        [SwaggerResponse(200, type: typeof(ICollection<RoomDto>))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<RoomDto>>> GetAllRoomsAsync()
        {
            try
            {
                return new JsonResult(await _roomService.GetAllRoomsAsync());
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }

        [HttpGet]
        [Route("GetRoomByIdAsync/{id}")]
        [SwaggerOperation("Get room by Id")]
        [SwaggerResponse(200, type: typeof(RoomDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<RoomDto>> GetRoomByIdAsync(int id)
        {
            try
            {
                return new JsonResult(await _roomService.GetRoomByIdAsync(id));
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }

        [HttpGet]
        [Route("GetAvailablesRoomsAsync/{startDate}/{endDate}")]
        [SwaggerOperation("Get all the availables rooms")]
        [SwaggerResponse(200, type: typeof(ICollection<RoomDto>))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<RoomDto>>> GetAvailablesRoomsAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                return new JsonResult(await _roomService.GetAvailablesRoomsAsync(startDate, endDate));
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }

        [HttpPatch]
        [Route("ChangeRoomStatusAsync/{id}/{status}")]
        [SwaggerOperation("Change the room status")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> ChangeRoomStatusAsync(int id, RoomStatus status)
        {
            try
            {
                return new JsonResult(await _roomService.ChangeRoomStatusAsync(id, status));
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }

        [HttpGet]
        [Route("IsAvailableRoomAsync/{id}/{startDate}/{endDate}")]
        [SwaggerOperation("Check if the room is available")]
        [SwaggerResponse(200, type: typeof(ICollection<bool>))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<bool>>> IsAvailableRoomAsync(int id, DateTime startDate, DateTime endDate)
        {
            try
            {
                return new JsonResult(await _roomService.IsAvailableRoomAsync(id, startDate, endDate));
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }

        [HttpDelete]
        [Route("DeleteRoomAsync/{id}")]
        [SwaggerOperation("Delete room")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> DeleteRoomAsync(int id)
        {
            try
            {
                return new JsonResult(await _roomService.DeleteRoomAsync(id));
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }

        [HttpGet]
        [Route("GetRoomByRoomNumberAsync/{roomNumber}")]
        [SwaggerOperation("Get the room by room number")]
        [SwaggerResponse(200, type: typeof(RoomDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<RoomDto>> GetRoomByRoomNumberAsync(string roomNumber)
        {
            try
            {
                return new JsonResult(await _roomService.GetRoomByRoomNumberAsync(roomNumber));
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }

        [HttpPut]
        [Route("UpdateRoomAsync")]
        [SwaggerOperation("Update room")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> UpdateRoomAsync([FromBody] RoomDto room)
        {
            try
            {
                return new JsonResult(await _roomService.UpdateRoomAsync(room));
            }
            catch (System.Exception ex)
            {
                BusinessException businessException = (BusinessException)ex;
                if (!(ex is BusinessException))
                {
                    throw ex;
                }

                return await ActionResultExceptionHelper.ResultException(businessException, HttpContext);
            }
        }
        #endregion
    }
}
