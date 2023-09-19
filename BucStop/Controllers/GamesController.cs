using Microsoft.AspNetCore.Mvc;

namespace BucStop.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Snake()
        {
            return View();
        }
    }
}
