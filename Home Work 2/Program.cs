// создаем объект класс строитель ( WebApplications )


using System.Text.Json.Serialization;

var build = WebApplication.CreateBuilder(args);

var app = build.Build();

app.UseStaticFiles();

app.Run(async (ctx) =>
{
    var path = Uri.UnescapeDataString(ctx.Request.Path);
    string? query = ctx.Request.QueryString.ToString();
    Console.WriteLine(query);

    if (query == "?restaurants")
    {
        List<Restaurant> restaurants = new List<Restaurant>(new[]
        {
            new Restaurant("Гурманское наслаждение",
                "Изысканный ресторан, где вы сможете насладиться изысканными блюдами и неповторимой атмосферой.",
                "Ukraine", "Kiev"),
            new Restaurant("Вкусные секреты",
                "Уютное место, где каждое блюдо приготовлено с любовью и вниманием к деталям", "Ukraine", "Kiev"),
            new Restaurant("Рестофесть",
                "Ресторан с прекрасным видом, где вы сможете насладиться великолепными блюдами и потрясающими закатами.",
                "Ukraine", "Kiev"),
            new Restaurant("Гастрономический рай",
                "Инновационный ресторан, где вас ждут смелые сочетания вкусов и оригинальные кулинарные решения.",
                "Ukraine", "Kiev"),
            new Restaurant("Ароматные кулинарные чудеса",
                "Место, где гастрономические вкусы встречаются с традиционными рецептами, чтобы создать неповторимый опыт.",
                "Ukraine", "Kiev"),
            new Restaurant("Кулинарное путешествие",
                "Ресторан, где каждое блюдо - это произведение искусства, сочетающее в себе элегантность и восхитительный вкус.",
                "Ukraine", "Kiev"),
            new Restaurant("Сладкий уголок",
                "Оазис для гурманов, предлагающий широкий выбор изысканных блюд и отличный сервис.", "Ukraine",
                "Kiev"),
            new Restaurant("Уютная трапеза",
                "Ресторан, где деликатесы и свежие ингредиенты воплощаются в блюдах, вызывающих настоящий восторг.",
                "Ukraine", "Kiev"),
        });

        ctx.Response.Headers.ContentType = "application/json; charset=utf-8";
        await ctx.Response.WriteAsJsonAsync(restaurants);
    }
    else if (path == "/GetRandomSymbol")
    {
        char randomChar = (char)new Random().Next('a', 'z' + 1);
        ctx.Response.Headers.ContentType = "application/json; charset=utf-8";
        await ctx.Response.WriteAsJsonAsync(randomChar);
    }
    else if (path == "/GetDayOfYear")
    {
        ctx.Response.Headers.ContentType = "application/json; charset=utf-8";
        await ctx.Response.WriteAsJsonAsync(DateTime.Now.DayOfYear);
    }
    else if (path == "/css/style.css")
    {
        ctx.Response.ContentType = "text/css";
        await ctx.Response.SendFileAsync("wwwroot/css/styles.css");
    }
    else if (path == "/Task1")
    {
        ctx.Response.ContentType = "text/html; charset=utf-8";
        await ctx.Response.SendFileAsync("Pages/Task1.html");
    }
    else if (path == "/Task2")
    {
        ctx.Response.ContentType = "text/html; charset=utf-8";
        await ctx.Response.SendFileAsync("Pages/Task2.html");
    }
    else if (path == "/Task3_4")
    {
        ctx.Response.ContentType = "text/html; charset=utf-8";
        await ctx.Response.SendFileAsync("Pages/Task3_4.html");
    }
    else if (path == "/Task5")
    {
        ctx.Response.ContentType = "text/html; charset=utf-8";
        await ctx.Response.SendFileAsync("Pages/Task5.html");
    }
    else
    {
        ctx.Response.ContentType = "text/html; charset=utf-8";
        await ctx.Response.SendFileAsync("Pages/HomePage.html");
    }
});

app.Run();

public record Restaurant(string? Name,string Description,string Country,string City);