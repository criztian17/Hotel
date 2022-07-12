using Hotel.Api.Helpers;
using Hotel.Common.DTOs;
using Hotel.Common.Exceptions;
using Hotel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation("Create guest")]
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

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        } 

        #endregion
    }
}
