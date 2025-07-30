using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Controllers.MVC_Controller;

namespace Task_Management_System.Controllers.API_Controller
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DM_Task_ApiController : ControllerBase
    {
        DM_Task_Controller objCtrl_Task = new DM_Task_Controller();

        [HttpGet]
        public IActionResult Get_Tasks()
        {
            return Ok();
        }
    }
}
