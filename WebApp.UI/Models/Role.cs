using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.UI.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // Navigation property to UserRole
        public ICollection<UserRole> UserRoles { get; set; }

        // Navigation property to RoleDetails
        public ICollection<RoleDetails> RoleDetails { get; set; }
    }
}
