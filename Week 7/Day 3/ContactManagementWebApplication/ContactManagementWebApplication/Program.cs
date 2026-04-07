var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// DI Registration
builder.Services.AddSingleton<ContactManagementWebApplication.Services.IContactService, ContactManagementWebApplication.Services.ContactService>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}"
);

app.MapControllers();

app.Run();
