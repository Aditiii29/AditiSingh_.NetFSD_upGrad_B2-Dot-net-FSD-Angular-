var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();

// Default route → opens calculator directly
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Add}/{id?}"
);

// Enable attribute routing
app.MapControllers();

app.Run();