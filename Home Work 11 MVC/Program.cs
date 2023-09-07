var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    "Processors",
    "Processors",
    new { controller = "Processors", action = "ProcessorsResult" });
app.MapControllerRoute(
    "About",
    "About",
    new { controller = "Home", action = "About" });
app.MapControllerRoute(
    "ProcessorDetails",
    "ProcessorDetails",
    new { controller = "Processors", action = "ProcessorDetails" });
app.MapControllerRoute(
    "MessagesModerator",
    "MessagesModerator",
    new { controller = "ModeratorControlls", action = "MessagesModerator" });

app.MapControllerRoute(
    "MessagesModerator",
    "MessagesModerator",
    new { controller = "ModeratorControlls", action = "MessagesForModerator" });
app.Run();