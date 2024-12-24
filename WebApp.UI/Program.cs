using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApp.UI.Data;

var builder = WebApplication.CreateBuilder(args);

//Service Registers
builder.Services.AddControllersWithViews();
//Connection String
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{action=Index}/{id?}");

app.Run();
