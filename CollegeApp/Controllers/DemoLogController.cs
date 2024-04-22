using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoLogController : ControllerBase
    {
        private readonly ILogger<DemoLogController> _logger;

        public DemoLogController(ILogger<DemoLogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _logger.LogTrace("Log message from Trace Method");
            _logger.LogDebug("Log message from Debug Method");
            _logger.LogInformation("Log message from Information Method");
            _logger.LogWarning("Log message from Warning Method");
            _logger.LogError("Log message from Error Method");
            _logger.LogCritical("Log message from Critical Method");

            return Ok();
        }
    }
}
