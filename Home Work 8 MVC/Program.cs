var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // добавляем сервисы MVC
var app = builder.Build();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();