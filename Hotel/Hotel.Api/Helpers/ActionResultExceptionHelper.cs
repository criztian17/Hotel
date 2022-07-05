using Hotel.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Api.Helpers
{
    public static class ActionResultExceptionHelper
    {
        /// <summary>
        /// Custom ActionResult for exceptions
        /// </summary>
        /// <param name="businessException">BusinessException object</param>
        /// <param name="httpContext">HttpContext object</param>
        /// <returns>ActionResult</returns>
        public static async Task<ActionResult> ResultException(BusinessException businessException, HttpContext httpContext)
        {
            httpContext.Response.StatusCode = businessException.StatusCode;
            return new JsonResult(await Task.FromResult(businessException.Result));
        }
    }
}
