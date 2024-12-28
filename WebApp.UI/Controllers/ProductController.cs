using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.UI.Data;
using WebApp.UI.Models;

namespace WebApp.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> productList = _context.Products.Include(x => x.Category).Select(y => new Product
            {
                ProductId = y.ProductId,
                Name = y.Name,
                UnitPrice = y.UnitPrice,
                CategoryId = y.CategoryId,
                Category = y.Category
            }).ToList();
            return View(productList);
        }


        [HttpGet]
        public IActionResult Upsert(int productId)
        {
            Product product = new Product();
            if (productId > 0)
            {
                product = _context.Products.Find(productId);
            }
            var Categories = _context.Categories.ToList();
            ViewBag.CategoryList = new SelectList(Categories, "CategoryId", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Upsert(Product product)
        {
            if (product.ProductId > 0)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int productId)
        {
            //Find object
            Product? product = _context.Products.Find(productId);

            //Delete
            _context.Products.Remove(product);
            _context.SaveChanges();

            //Redirect
            //return RedirectToAction("Index", "Category");
            return RedirectToAction(nameof(Index));
        }
    }
}
