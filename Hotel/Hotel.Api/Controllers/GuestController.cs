using Hotel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
