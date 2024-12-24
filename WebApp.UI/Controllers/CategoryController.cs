using Microsoft.AspNetCore.Mvc;
using WebApp.UI.Data;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // state variable => viewbag, viewdata, tempdate, session
            //models 
            List<Category> CategoryList = _context.Categories.ToList();

            return View(CategoryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            _context.Categories.Add(model);
            _context.SaveChanges();

           return RedirectToAction("Index", "Category");
        }

        //List, Create, Edit, Delete
    }
}
