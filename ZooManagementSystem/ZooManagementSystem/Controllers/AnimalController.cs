using Microsoft.AspNetCore.Mvc;

namespace ZooManagementSystem.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
