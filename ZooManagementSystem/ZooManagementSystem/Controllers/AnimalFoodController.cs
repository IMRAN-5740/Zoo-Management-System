using Microsoft.AspNetCore.Mvc;

namespace ZooManagementSystem.Controllers
{
    public class AnimalFoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
