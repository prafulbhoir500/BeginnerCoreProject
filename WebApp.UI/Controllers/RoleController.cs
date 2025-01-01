using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.UI.Data;
using WebApp.UI.Models;
using WebApp.UI.ViewModels.AppModuleViewModels;
using WebApp.UI.ViewModels.RoleViewModels;

namespace WebApp.UI.Controllers
{
    public class RoleController : Controller
    {
        private readonly AppDbContext _context;

        public RoleController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Role> roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult Upsert(int roleId)
        {
            Role role = new Role();
            if (roleId > 0)
            {
                role = _context.Roles.Find(roleId);
            }
            return View(role);
        }

        [HttpPost]
        public IActionResult Upsert(Role role)
        {
            if (role.RoleId > 0)
            {
                _context.Roles.Update(role);
                _context.SaveChanges();
            }
            else
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int roleId)
        {
            //Find object
            Role role = _context.Roles.Find(roleId);

            //Delete
            _context.Roles.Remove(role);
            _context.SaveChanges();

            //Redirect
            //return RedirectToAction("Index", "Category");
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RoleDetail(int roleId)
        {
            CreateRoleDetailViewModel model = new CreateRoleDetailViewModel()
            {
                Role = _context.Roles.Find(roleId),
                moduleTemplate = _context.AppModuleTemplates.Include(x=>x.AppModule).ToList()
            };
            // Fetch modules to display in the table
            //var modules = _context.AppModules
            //    .Select(m => new AppModuleTemplate
            //    {
            //        AppModuleId = m.AppModuleId,
            //        ViewAccess = false,
            //        EditAccess = false,
            //        ApproveAccess = false,
            //        UploadAccess = false,
            //        DeleteAccess = false,
            //        ApprovedAccess = false,
            //        PrintAccess = false
            //    }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult RoleDetail(CreateRoleDetailViewModel model)
        {

            int roleId = model.Role.RoleId;

            foreach(var item in model.moduleTemplate)
            {
                RoleDetails rd = new RoleDetails
                {
                    RoleId = roleId,
                    AppModuleId=item.AppModuleId,
                    ViewAccess = item.ViewAccess,
                    EditAccess = item.EditAccess,
                    DeleteAccess = item.DeleteAccess,
                    ApprovedAccess=item.ApproveAccess,
                    UploadAccess = item.UploadAccess,
                    PrintAccess = item.PrintAccess,
                }; 

                _context.Add(rd);
            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
