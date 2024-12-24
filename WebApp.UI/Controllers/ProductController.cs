using Microsoft.AspNetCore.Mvc;

namespace WebApp.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
