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
            try
            {
                _context.Categories.Add(model);
                _context.SaveChanges();

                TempData["Success"] = "Saved Successfully";
                return RedirectToAction("Index", "Category");
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMsg"]=msg;
                return View();
            }
        }

        //List, Create, Edit, Delete

        [HttpGet]
        public IActionResult Edit(int CategoryId)
        {
            Category? category = _context.Categories.FirstOrDefault(x => x.CategoryId == CategoryId);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            _context.Categories.Update(model);
            _context.SaveChanges();
            TempData["Success"] = "Updated Successfully";
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult Delete(int CategoryId)
        {
            //Find object
            Category? category = _context.Categories.Find(CategoryId);

            //Delete
            _context.Categories.Remove(category);
            _context.SaveChanges();

            //Redirect
            //return RedirectToAction("Index", "Category");
            return RedirectToAction(nameof(Index));
        }
    }
}
