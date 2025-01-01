using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.UI.Models;

namespace WebApp.UI.ViewModels.RoleViewModels
{
    public class CreateRoleDetailViewModel
    {
        public Role Role { get; set; }
        public List <AppModuleTemplate> moduleTemplate { get; set; }
    }
}
