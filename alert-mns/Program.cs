// Add DI (Dependency Injection) - AddService
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel server options
builder.WebHost.UseUrls("http://*:5084"); // Écoute sur toutes les interfaces réseau

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