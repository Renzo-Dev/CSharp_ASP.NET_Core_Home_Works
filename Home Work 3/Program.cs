using Home_Work_3;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// создаем пользователей ( временная БД ) 
var users = new List<User>
{
    new(Guid.NewGuid().ToString(), "Dan", "Koshevoy", 22, "2001-07-19"),
    new(Guid.NewGuid().ToString(), "John", "Doe", 35, "1994-03-20"),
    new(Guid.NewGuid().ToString(), "Alice", "Smith", 29, "2002-01-20"),
    new(Guid.NewGuid().ToString(), "Robert", "Brown", 20, "1967-05-01"),
    new(Guid.NewGuid().ToString(), "Michel", "Johnson", 38, "1999-12-03")
};

app.UseStaticFiles();

app.MapWhen(ctx => ctx.Request.Method == "GET" && ctx.Request.Path.StartsWithSegments("/users"), GetAllUsers);
app.MapWhen(ctx => ctx.Request.Method == "POST" && ctx.Request.Path.StartsWithSegments("/users"), CreateUser);
app.MapWhen(ctx => ctx.Request.Method == "PUT" && ctx.Request.Path.StartsWithSegments("/users"), EditUser);
///////////////
///////////////
/////////////// СДЕЛАТЬ ЧЕРЕЗ MAP
///////////////
///////////////
///////////////

app.Map("/Task1", Task1);
app.Map("/Task2", Task2);
app.Run(async ctx =>
{
    ctx.Response.ContentType = "text/html; charset=UTF-8";
    await ctx.Response.SendFileAsync("Pages/index.html");
});

app.Run();

// создать и добавить пользователя
void CreateUser(IApplicationBuilder app)
{
    app.Run(async ctx =>
    {
        Console.WriteLine(ctx.Request.Path);
        Console.WriteLine(ctx.Request.Method);
        try
        {
            // получаем данные пользователя
            var user = await ctx.Request.ReadFromJsonAsync<User>();
            if (user != null)
            {
                // устанавливаем id для нового пользователя
                user.Guid = Guid.NewGuid().ToString();
                // добавляем пользователя в список
                users.Add(user);
                await ctx.Response.WriteAsJsonAsync(user);
            }
            else
            {
                throw new Exception("Некорректные данные");
            }
        }
        catch (Exception)
        {
            ctx.Response.StatusCode = 400;
            ctx.Response.ContentType = "text/html; charset=UTF-8";
            await ctx.Response.WriteAsJsonAsync(new { message = "Incorrect data" });
        }
    });
}

void EditUser(IApplicationBuilder app)
{
    app.Run(async ctx =>
    {
        try
        {
            // получаем данные пользователя
            var userData = await ctx.Request.ReadFromJsonAsync<User>();
            if (userData != null)
            {
                // получаем пользователя по id
                var user = users.FirstOrDefault(u => u.Guid == userData.Guid);
                // если пользователь найден, изменяем его данные и отправляем обратно клиенту
                if (user != null)
                {
                    user.FirstName = userData.FirstName;
                    user.LastName = userData.LastName;
                    user.Age = userData.Age;
                    user.BirthDate = userData.BirthDate;
                    await ctx.Response.WriteAsJsonAsync(user);
                }
                else
                {
                    ctx.Response.StatusCode = 404;
                    await ctx.Response.WriteAsJsonAsync(new { message = "User not found" });
                }
            }
            else
            {
                throw new Exception("Incorrect data");
            }
        }
        catch (Exception)
        {
            ctx.Response.StatusCode = 400;
            await ctx.Response.WriteAsJsonAsync(new { message = "Incorrect data" });
        }
    });
}

// получение всех пользователей
void GetAllUsers(IApplicationBuilder app)
{
    app.Run(async ctx =>
    {
        ctx.Response.ContentType = "application/json";
        await ctx.Response.WriteAsJsonAsync(users);
    });
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
    app.Run(async ctx =>
    {
        ctx.Response.ContentType = "text/html; charset=UTF-8";
        await ctx.Response.SendFileAsync("Pages/Task2.html");
    });
}