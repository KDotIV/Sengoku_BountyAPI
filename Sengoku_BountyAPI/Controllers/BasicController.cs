using Microsoft.AspNetCore.Mvc;

namespace Sengoku_BountyAPI.Controllers
{
    public class BasicController : ControllerBase
    {
        private readonly ILogger<BasicController> _logger;

        public BasicController(ILogger<BasicController> logger)
        {
            _logger = logger;
        }
    }
}
