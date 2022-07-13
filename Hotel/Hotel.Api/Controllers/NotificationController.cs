//using Hotel.Service.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace Hotel.Api.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class NotificationController : ControllerBase
//    {
//        #region Attributes
//        private readonly INotificationService _notificationService;
//        #endregion

//        #region Constructor
//        public NotificationController(INotificationService notificationService)
//        {
//            _notificationService = notificationService;
//        }
//        #endregion

//        #region Actions
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        } 
//        #endregion
//    }
//}
