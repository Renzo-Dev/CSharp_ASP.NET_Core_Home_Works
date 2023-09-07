var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    "Task1",
    "Task1",
    new { controller = "Home", action = "Task1" });
app.MapControllerRoute(
    "Task2",
    "Task2",
    new { controller = "Home", action = "Task2" });
app.MapControllerRoute(
    "About",
    "About",
    new { controller = "Home", action = "About" });
app.MapControllerRoute(
    "News",
    "News",
    new { controller = "Home", action = "News" });
app.MapControllerRoute(
    "Gallery",
    "Gallery",
    new { controller = "Home", action = "Gallery" });

app.Run();