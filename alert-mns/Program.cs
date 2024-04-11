// Add DI (Dependency Injection) - AddService
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configure pipeline - Use and Map methods
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
