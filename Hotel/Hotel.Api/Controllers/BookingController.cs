using Hotel.Common.DTOs;
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

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
