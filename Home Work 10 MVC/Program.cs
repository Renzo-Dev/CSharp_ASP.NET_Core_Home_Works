var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();


app.UseStaticFiles();
app.MapControllerRoute(
    "default",
    "{controller}/{action}",
    new { controller = "PageInfo", action = "PageInfoGenerator" });
app.MapControllerRoute(
    "Python",
    "Python",
    new { controller = "PageInfo", action = "Python" });
app.MapControllerRoute(
    "C#",
    "CSharp",
    new { controller = "PageInfo", action = "CSharp" });
app.MapControllerRoute(
    "C++",
    "C++",
    new { controller = "PageInfo", action = "CPlus_Plus" });
app.MapControllerRoute(
    "JavaScript",
    "JavaScript",
    new { controller = "PageInfo", action = "JavaScript" });
app.MapControllerRoute(
    "UnrealEngine",
    "UnrealEngine",
    new { controller = "PageInfo", action = "UnrealEngine" });


app.Run();