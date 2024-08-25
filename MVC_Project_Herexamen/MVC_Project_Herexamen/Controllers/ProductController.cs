using Microsoft.AspNetCore.Mvc;

namespace MVC_Project_Herexamen.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
