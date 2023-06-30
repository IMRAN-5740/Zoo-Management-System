using Microsoft.AspNetCore.Mvc;

namespace ZooManagementSystem.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
