using Hotel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
