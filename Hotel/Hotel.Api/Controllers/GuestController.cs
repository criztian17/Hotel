using Hotel.Api.Helpers;
using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
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
    public class GuestController : ControllerBase
    {
        #region Attributes
        private readonly IGuestService _guestService;
        #endregion

        #region Constructor
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        #endregion

        #region Actions

        [HttpPost]
        [Route("CreateGuestAsync")]
        [SwaggerOperation("Create guest")]
        [SwaggerResponse(200, type: typeof(GuestDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<GuestDto>> CreateGuestAsync([FromBody] BaseGuestDto guest)
        {
            try
            {
                return new JsonResult(await _guestService.CreateGuestAsync(guest));
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
        [Route("GetAllGuestsAsync")]
        [SwaggerOperation("Get all guests")]
        [SwaggerResponse(200, type: typeof(ICollection<GuestDto>))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<ICollection<GuestDto>>> GetAllGuestsAsync()
        {
            try
            {
                return new JsonResult(await _guestService.GetAllGuestsAsync());
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
        [Route("GetGuestByEmailAsync/{email}")]
        [SwaggerOperation("Get guest by email")]
        [SwaggerResponse(200, type: typeof(GuestDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<GuestDto>> GetGuestByEmailAsync(string email)
        {
            try
            {
                return new JsonResult(await _guestService.GetGuestByEmailAsync(email));
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
        [Route("DeleteGuestAsync/{id}")]
        [SwaggerOperation("Delete guest")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> DeleteGuestAsync(int id)
        {
            try
            {
                return new JsonResult(await _guestService.DeleteGuestAsync(id));
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
        [Route("GetGuestByIdAsync/{id}")]
        [SwaggerOperation("Get guest by Id")]
        [SwaggerResponse(200, type: typeof(GuestDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<GuestDto>> GetGuestByIdAsync(int id)
        {
            try
            {
                return new JsonResult(await _guestService.GetGuestByIdAsync(id));
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
        [Route("UpdateGuestdAsync")]
        [SwaggerOperation("Get guest by Id")]
        [SwaggerResponse(200, type: typeof(GuestDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<GuestDto>> UpdateGuestdAsync([FromBody]GuestDto updatedGuest)
        {
            try
            {
                return new JsonResult(await _guestService.UpdateGuestAsync(updatedGuest));
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
