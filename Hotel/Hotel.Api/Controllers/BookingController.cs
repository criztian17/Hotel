using Hotel.Api.Helpers;
using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using Hotel.Common.Exceptions;
using Hotel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        #region Attributes
        private readonly IBookingService _bookingService;
        #endregion

        #region Constructor
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        #endregion

        #region Actions

        [HttpPost]
        [Route("CreateBookingAsync")]
        [SwaggerOperation("Create booking")]
        [SwaggerResponse(200, type: typeof(FullBookingDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<FullBookingDto>> CreateBookingAsync([FromBody] BookingDto booking)
        {
            try
            {
                return new JsonResult(await _bookingService.CreateBookingAsync(booking));
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
        [Route("GetBookingByIdAsync/{id}")]
        [SwaggerOperation("Get booking by Id")]
        [SwaggerResponse(200, type: typeof(FullBookingDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<FullBookingDto>> GetBookingByIdAsync(int id)
        {
            try
            {
                return new JsonResult(await _bookingService.GetBookingByIdAsync(id));
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
        [Route("GetAllBookingsAsync")]
        [SwaggerOperation("Get all bookings")]
        [SwaggerResponse(200, type: typeof(ICollection<FullBookingDto>))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<FullBookingDto>>> GetAllBookingsAsync()
        {
            try
            {
                return new JsonResult(await _bookingService.GetAllBookingsAsync());
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
        [Route("UpdateBookingAsync/{id}")]
        [SwaggerOperation("Update booking")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> UpdateBookingAsync(int id, [FromBody] BaseBookingDto booking)
        {
            try
            {
                return new JsonResult(await _bookingService.UpdateBookingAsync(id, booking));
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
        [Route("ChangeBookingStatusAsync/{id}/{status}")]
        [SwaggerOperation("Change the booking status")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> ChangeBookingStatusAsync(int id, BookingStatus status)
        {
            try
            {
                return new JsonResult(await _bookingService.ChanceBookingStatus(id, status));
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
