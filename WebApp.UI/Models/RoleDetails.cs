using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.UI.Models
{
    public class RoleDetails
    {
        [Key]
        public int RoleDetailId { get; set; }
        public int RoleId { get; set; }
        public int AppModuleId { get; set; }
        public bool ViewAccess { get; set; }
        public bool EditAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public bool ApprovedAccess { get; set; }
        public bool UploadAccess { get; set; }
        public bool PrintAccess { get; set; }

        // Navigation properties
        public virtual Role Role { get; set; }
        public virtual AppModule AppModule { get; set; }
    }
}
