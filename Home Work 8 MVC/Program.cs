var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    name: "Task1",
    pattern: "Task1",
    defaults: new { controller = "Home", action = "Task1" });
app.MapControllerRoute(
    name: "Task2",
    pattern: "Task2",
    defaults: new { controller = "Home", action = "Task2" });

app.Run();