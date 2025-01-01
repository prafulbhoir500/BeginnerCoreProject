using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.UI.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public int UserId { get; set; }  // Assuming AspNetUsers table has an Id column
        public int RoleId { get; set; }

        // Navigation properties
        public virtual Role Role { get; set; }
        public virtual UserInfo UserInfo { get; set; } // Assuming ApplicationUser is the Identity user model

    }
}
