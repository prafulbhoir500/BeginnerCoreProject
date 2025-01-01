using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.UI.Models;

namespace WebApp.UI.Data
{
    // Libraries that need to install
    // 1. Microsoft.EntityFrameworkCore
    // 2. Microsoft.EntityFrameworkCore.Design
    // 3. Microsoft.EntityFrameworkCore.SqlServer
    // 4. Microsoft.EntityFrameworkCore.Tools
    public class AppDbContext : DbContext
    {

        //ctro
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



        //DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppModule> AppModules { get; set; }
        public DbSet<AppModuleTemplate> AppModuleTemplates { get; set; }
        public DbSet<RoleDetails> RoleDetails { get; set; }

    }
}
