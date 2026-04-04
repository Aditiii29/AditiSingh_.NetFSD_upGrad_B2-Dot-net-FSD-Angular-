using DAL.Data;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register MVC - enables Controllers and Views
builder.Services.AddControllersWithViews();

// Register EF Core - connects AppDbContext to SQL Server
// Reads connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Register Repository for Dependency Injection
// When controller asks for IContactRepository
// ASP.NET gives it ContactRepository automatically
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default route - opens Contact/ShowContacts on startup
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}");

app.Run();