using System.Text.RegularExpressions;
using Home_Work_3;

// создаем пользователей ( временная БД ) 
var users = new List<User>
{
    new(Guid.NewGuid().ToString(), "Dan", "Koshevoy", 22, "2001-07-19"),
    new(Guid.NewGuid().ToString(), "John", "Doe", 35, "1994-03-20"),
    new(Guid.NewGuid().ToString(), "Alice", "Smith", 29, "2002-01-20"),
    new(Guid.NewGuid().ToString(), "Robert", "Brown", 20, "1967-05-01"),
    new(Guid.NewGuid().ToString(), "Michel", "Johnson", 38, "1999-12-03")
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseWhen(ctx => ctx.Request.Path.StartsWithSegments("/upload"),
    app =>
    {
        app.MapWhen(ctx => ctx.Request.Method == "POST", app =>
        {
            app.Run(async ctx =>
            {
                // получаем отправленные файлы формы
                var files = ctx.Request.Form.Files;
                ctx.Response.ContentType = "text/html; charset=utf-8";

                // путь к папке с файлами и подпапкам
                var uploadPath = $@"{Environment.CurrentDirectory}\uploads";
                var photoFolder = Path.Combine(uploadPath, "Photo");
                var textFolder = Path.Combine(uploadPath, "Text");

                // создаем папки
                Directory.CreateDirectory(photoFolder);
                Directory.CreateDirectory(textFolder);

                foreach (var file in files)
                {
                    // получаем тип(расширение) файла
                    var fileExtension = Path.GetExtension(file.FileName).TrimStart('.').ToLower();
                    // 
                    if (fileExtension is "jpg" or "png" or "gif")
                    {
                        using (var fileStream = new FileStream($"{photoFolder}/{file.FileName}", FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                    else if (fileExtension is "txt" or "doc" or "pdf")
                    {
                        using (var fileStream = new FileStream($"{textFolder}/{file.FileName}", FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        await ctx.Response.WriteAsync("Файлы успешно загружены");
                    }
                }
            });
        });
    });
app.UseWhen(ctx => ctx.Request.Path.StartsWithSegments("/users"), app =>
{
    var expressionForGuid = @"^/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    app.MapWhen(ctx => ctx.Request.Method == "GET" && Regex.IsMatch(ctx.Request.Path, expressionForGuid), GetUser);
    app.MapWhen(ctx => ctx.Request.Method == "DELETE" && Regex.IsMatch(ctx.Request.Path, expressionForGuid),
        RemoveUser);
    app.MapWhen(ctx => ctx.Request.Method == "GET", GetAllUsers);
    app.MapWhen(ctx => ctx.Request.Method == "POST", CreateUser);
    app.MapWhen(ctx => ctx.Request.Method == "PUT", EditUser);
});

app.Map("/Task1", Task1);
app.Map("/Task2", Task2);
app.Run(async ctx =>
{
    ctx.Response.ContentType = "text/html; charset=UTF-8";
    await ctx.Response.SendFileAsync("Pages/index.html");
});

app.Run();

void RemoveUser(IApplicationBuilder app)
{
    app.Run(async ctx =>
    {
        var id = ctx.Request.Path.Value?.Split("/")[2];
        // получаем пользователя по id

        var user = users.FirstOrDefault(u => u.Guid == id);
        // если пользователь найден, удаляем его
        if (user != null)
        {
            users.Remove(user);
            await ctx.Response.WriteAsJsonAsync(user);
        }
        // если не найден, отправляем статусный код и сообщение об ошибке
        else
        {
            ctx.Response.StatusCode = 404;
            await ctx.Response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
        }
    });
}

void GetUser(IApplicationBuilder app)
{
    app.Run(async ctx =>
    {
        var id = ctx.Request.Path.Value?.Split("/")[2];
        // получаем пользователя по id

        foreach (var user in users)
            if (user.Guid == id)
            {
                await ctx.Response.WriteAsJsonAsync(user);
                return;
            }

        ctx.Response.StatusCode = 404;
        await ctx.Response.WriteAsJsonAsync(new { message = "User not found" });
    });
}

// создать и добавить пользователя
void CreateUser(IApplicationBuilder app)
{
    app.Run(async ctx =>
    {
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