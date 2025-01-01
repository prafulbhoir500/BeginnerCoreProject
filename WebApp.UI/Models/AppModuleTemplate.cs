using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.UI.Models
{
    public class AppModuleTemplate
    {
        [Key]
        public int AppModuleTemplateId { get; set; }
        public int AppModuleId { get; set; }
        public bool ViewAccess { get; set; }
        public bool EditAccess { get; set; }
        public bool ApproveAccess { get; set; }
        public bool UploadAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public bool PrintAccess { get; set; }

        // Navigation properties
        public virtual AppModule AppModule { get; set; }
    }
}
