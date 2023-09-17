using Home_Work_15_MVC.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ThrottlingFilter>();
// глобальный фильтр
builder.Services.AddMvc(options => { options.Filters.Add(typeof(LogActionFilter)); });

builder.Services.AddMemoryCache();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}");
app.Run();