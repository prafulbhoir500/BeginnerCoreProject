using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.UI.Models
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; } // Primary key
        public string Name { get; set; } // New column
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsOnline { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
