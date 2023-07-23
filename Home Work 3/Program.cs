using Home_Work_3;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var users = new List<User>
{
    // new(){ Guid = Guid.NewGuid().ToString(),FirstName = "Dan",LastName = "Koshevoy",},
    new(Guid.NewGuid().ToString(), "Dan", "Koshevoy", 22, new DateTime(2001, 7, 19)),
    new(Guid.NewGuid().ToString(), "John", "Doe", 35, new DateTime(2023, 7, 23)),
    new(Guid.NewGuid().ToString(),"Alice", "Smith", 29, new DateTime(2023, 7, 23)),
    new(Guid.NewGuid().ToString(),"Robert", "Brown", 20, new DateTime(2023, 7, 23)),
    new(Guid.NewGuid().ToString(),"Michel", "Johnson", 38, new DateTime(2023, 7, 23))
};

app.UseStaticFiles();

app.Map("/Task1", Task1);
app.Map("/Task2", Task2);
app.Run(async (ctx) =>
{
    var path = Uri.UnescapeDataString(ctx.Request.Path);
    
    ctx.Response.ContentType = "text/html; charset=UTF-8";
    await ctx.Response.SendFileAsync("Pages/index.html");
});

app.Run();

static void Task1(IApplicationBuilder app)
{
    app.Run(async ctx =>
    {
        ctx.Response.ContentType = "text/html; charset=UTF-8";
        await ctx.Response.SendFileAsync("Pages/Task1.html");
    });
}

static void Task2(IApplicationBuilder app)
{
    app.Run(async ctx => { await ctx.Response.SendFileAsync("Pages/Task2.html"); });
}