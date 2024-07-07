using Microsoft.EntityFrameworkCore;
using WebApplicationBYD.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); //Cấu hình file Partial

//Khởi gán kết  nối db
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"].ToString();

builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));


builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();


app.MapControllerRoute(
    name: "myareas",
    pattern: "{area:exists}/{controller}/{action}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

app.Run();
