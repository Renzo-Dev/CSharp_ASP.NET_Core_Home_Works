// создаем объект класс строитель ( WebApplications )

var build = WebApplication.CreateBuilder(args);

var app = build.Build();

app.UseStaticFiles();

app.Run(async (ctx) =>
{
    var path = Uri.UnescapeDataString(ctx.Request.Path);
    var query = ctx.Request.QueryString.ToString();

    if (query == "?countries")
    {
        List<Country> countries = new List<Country>
        {
            new Country("Соединенные Штаты Америки (США)", "Вашингтон, округ Колумбия", "Северная Америка", 331_000_000, "английский"),
            new Country("Франция", "Париж", "Европа", 67_000_000, "французский"),
            new Country("Китай", "Пекин", "Азия", 1_400_000_000, "китайский"),
            new Country("Бразилия", "Бразилиа", "Южная Америка", 213_000_000, "португальский"),
            new Country("Япония", "Токио", "Азия", 126_000_000, "японский")
        };
        ctx.Response.Headers.ContentType = "application/json; charset=utf-8";
        await ctx.Response.WriteAsJsonAsync(countries);
    }
    else if (query == "?restaurants")
    {
        List<Restaurant> restaurants = new List<Restaurant>(new[]
        {
            new Restaurant("Гурманское наслаждение",
                "Изысканный ресторан, где вы сможете насладиться изысканными блюдами и неповторимой атмосферой.",
                "Украина", "Киев"),
            new Restaurant("Вкусные секреты",
                "Уютное место, где каждое блюдо приготовлено с любовью и вниманием к деталям", "Украина", "Киев"),
            new Restaurant("Рестофесть",
                "Ресторан с прекрасным видом, где вы сможете насладиться великолепными блюдами и потрясающими закатами.",
                "Украина", "Киев"),
            new Restaurant("Гастрономический рай",
                "Инновационный ресторан, где вас ждут смелые сочетания вкусов и оригинальные кулинарные решения.",
                "Украина", "Киев"),
            new Restaurant("Ароматные кулинарные чудеса",
                "Место, где гастрономические вкусы встречаются с традиционными рецептами, чтобы создать неповторимый опыт.",
                "Украина", "Киев"),
            new Restaurant("Кулинарное путешествие",
                "Ресторан, где каждое блюдо - это произведение искусства, сочетающее в себе элегантность и восхитительный вкус.",
                "Украина", "Киев"),
            new Restaurant("Сладкий уголок",
                "Оазис для гурманов, предлагающий широкий выбор изысканных блюд и отличный сервис.", "Украина",
                "Киев"),
            new Restaurant("Уютная трапеза",
                "Ресторан, где деликатесы и свежие ингредиенты воплощаются в блюдах, вызывающих настоящий восторг.",
                "Украина", "Киев"),
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
public record Country(string Name, string Capital, string Continent, int Population, string OfficialLanguage);