using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApp.UI.Data;

var builder = WebApplication.CreateBuilder(args);

//Service Registers

//Connection String
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
