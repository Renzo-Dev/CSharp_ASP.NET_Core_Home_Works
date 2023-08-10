var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(options => { options.Conventions.AddPageRoute("/Pages/Book", "/book"); });

var app = builder.Build();


app.MapRazorPages();
app.UseRouting();
app.UseStaticFiles();

app.Run();