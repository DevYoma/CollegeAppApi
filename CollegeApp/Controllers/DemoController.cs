using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        // THIS CONTROLLER SHOWS TIGHTLY COUPLED DEPENDENCY INJECTION.

        // Questions
        // 1. why do we have to make a private instace. 2. what is the purpose of the constructor(refresh my memory) 
        private readonly IMyLogger _myLogger;

        public DemoController()
        {
            _myLogger = new LogToFile();
        }

        [HttpGet]
        public ActionResult Index ()
        {
            _myLogger.Log("Index method started");
            return Ok();
        }
    }
}
