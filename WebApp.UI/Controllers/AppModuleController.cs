using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.UI.Data;
using WebApp.UI.Models;
using WebApp.UI.ViewModels.AppModuleViewModels;

namespace WebApp.UI.Controllers
{
    public class AppModuleController : Controller
    {
        private readonly AppDbContext _context;

        public AppModuleController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<AppModule> appModules = _context.AppModules.ToList();
            return View(appModules);
        }
        [HttpGet]
        public IActionResult Upsert(int appModuleId)
        {
            AppModuleViewModel model = new AppModuleViewModel();


            if (appModuleId > 0)
            {
                model = new AppModuleViewModel
                {
                    AppModule = _context.AppModules.Find(appModuleId),
                    AppModuleTemplate = _context.AppModuleTemplates.FirstOrDefault(x => x.AppModuleId == appModuleId)

                };
            }

            var appModuleList = _context.AppModules.Where(x => string.IsNullOrEmpty(x.ModuleUrl)).ToList();
            ViewBag.AppModuleList = new SelectList(appModuleList, "AppModuleId", "ModuleName");

            return View(model);
        }
        [HttpPost]
        public IActionResult Upsert(AppModuleViewModel moduleViewModel)
        {
            if (moduleViewModel.AppModule.AppModuleId > 0)
            {

                _context.AppModules.Update(moduleViewModel.AppModule);
                if (moduleViewModel.AppModuleTemplate.AppModuleTemplateId > 0)
                {
                    _context.AppModuleTemplates.Update(moduleViewModel.AppModuleTemplate);
                }

                _context.SaveChanges();
            }
            else
            {
                // Step 1: Add the AppModule
                _context.AppModules.Add(moduleViewModel.AppModule);
                _context.SaveChanges(); // Save the AppModule to get the generated AppModuleId


                if (moduleViewModel.AppModule.ModuleUrl != null)
                {
                    // Step 2: Retrieve the AppModuleId of the newly added AppModule
                    var appModuleId = moduleViewModel.AppModule.AppModuleId;

                    // Step 3: Set the AppModuleId in the AppModuleTemplate
                    moduleViewModel.AppModuleTemplate.AppModuleId = appModuleId;

                    // Step 4: Add the AppModuleTemplate to the database
                    _context.AppModuleTemplates.Add(moduleViewModel.AppModuleTemplate);
                    _context.SaveChanges(); // Save the AppModuleTemplate
                }
            }

            return RedirectToAction("Index");
        }
    }
}
