using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.UI.Models
{
    public class AppModule
    {
        [Key]
        public int AppModuleId { get; set; }
        public int? ParentModuleId { get; set; }
        public string ModuleName { get; set; }
        public string? ModuleUrl { get; set; }
        public int? SortOrder { get; set; }

        // Navigation property to Parent AppModule (self-referencing)
        public virtual AppModule ParentModule { get; set; }

        // Navigation property to Child AppModules (self-referencing)
        public virtual ICollection<AppModule> ChildModules { get; set; }

        // Navigation property to RoleDetails
        public ICollection<RoleDetails> RoleDetails { get; set; }

        // Navigation property to AppModuleTemplate
        public ICollection<AppModuleTemplate> AppModuleTemplates { get; set; }
    }
}
