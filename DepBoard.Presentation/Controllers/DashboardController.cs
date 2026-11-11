using Microsoft.AspNetCore.Mvc;

namespace DepBoard.Presentation.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
