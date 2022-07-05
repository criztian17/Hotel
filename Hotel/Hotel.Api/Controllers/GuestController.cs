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
        [HttpGet]
        [Route("ExistsByIdAsync/{id}")]
        [SwaggerOperation("Check if guest exists")]
        [SwaggerResponse(200, type: typeof(bool))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> ExistsByIdAsync(int id)
        {
            try
            {
                return new JsonResult(await _guestService.ExistGuestByIdAsync(id));
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
        [Route("CreateGuestAsync")]
        [SwaggerOperation("Create guest")]
        [SwaggerResponse(200, type: typeof(GuestDto))]
        [SwaggerResponse(400, type: typeof(RuleError))]
        [SwaggerResponse(500, Description = "Internal Server Error")]
        public async Task<ActionResult<bool>> CreateGuestAsync([FromBody] GuestDto guest)
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

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //} 

        #endregion
    }
}
