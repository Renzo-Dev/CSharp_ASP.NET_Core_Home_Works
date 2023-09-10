var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    "Task2",
    "{controller=Home}/{action=Task2}");

app.Run();