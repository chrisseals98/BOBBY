using Microsoft.AspNetCore.Mvc;

namespace BucStop.Controllers
{
    public class SnakeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
