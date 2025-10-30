using BTL_WebProgramming.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BTL_WebProgramming.Models; 

var builder = WebApplication.CreateBuilder(args);

// add sevices to the container.
builder.Services.AddControllersWithViews();


// ✅ Thêm MyDbContext vào container DI
builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDb")));

// Các dịch vụ khác (MVC, Razor Page, v.v.)
builder.Services.AddControllersWithViews();

var app = builder.Build();

//



    // Middleware mặc định
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
