var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404 && !context.Response.HasStarted) context.Response.Redirect("/");
});
app.Run();