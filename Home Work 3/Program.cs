using Home_Work_3;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// создаем пользователей ( временная БД ) 
var users = new List<User>
{
    new(Guid.NewGuid().ToString(), "Dan", "Koshevoy", 22, new DateTime(2001, 7, 19)),
    new(Guid.NewGuid().ToString(), "John", "Doe", 35, new DateTime(2023, 7, 23)),
    new(Guid.NewGuid().ToString(), "Alice", "Smith", 29, new DateTime(2023, 7, 23)),
    new(Guid.NewGuid().ToString(), "Robert", "Brown", 20, new DateTime(2023, 7, 23)),
    new(Guid.NewGuid().ToString(), "Michel", "Johnson", 38, new DateTime(2023, 7, 23))
};

app.UseStaticFiles();

// 

app.Map("/users", GetAllUsers);
app.Map("/Task1", Task1);
app.Map("/Task2", Task2);
app.Run(async ctx =>
{
    Console.WriteLine(ctx.Request.Path);
    ctx.Response.ContentType = "text/html; charset=UTF-8";
    await ctx.Response.SendFileAsync("Pages/index.html");
});

app.Run();

// 
void GetAllUsers(IApplicationBuilder app)
{
    app.Run(async ctx => { await ctx.Response.WriteAsJsonAsync(users); });
}

// первая страница с заданием к ДЗ
static void Task1(IApplicationBuilder app)
{
    app.Run(async ctx =>
    {
        ctx.Response.ContentType = "text/html; charset=UTF-8";
        await ctx.Response.SendFileAsync("Pages/Task1.html");
    });
}

// вторая страница с заданием к ДЗ
static void Task2(IApplicationBuilder app)
{
    app.Run(async ctx => { await ctx.Response.SendFileAsync("Pages/Task2.html"); });
}