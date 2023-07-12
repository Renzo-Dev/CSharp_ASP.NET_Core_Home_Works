// ������� ������ ����� ��������� ( WebApplications )


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
            new Restaurant("���������� �����������",
                "���������� ��������, ��� �� ������� ����������� ����������� ������� � ������������ ����������.",
                "Ukraine", "Kiev"),
            new Restaurant("������� �������",
                "������ �����, ��� ������ ����� ������������ � ������� � ��������� � �������", "Ukraine", "Kiev"),
            new Restaurant("����������",
                "�������� � ���������� �����, ��� �� ������� ����������� ������������� ������� � ������������ ��������.",
                "Ukraine", "Kiev"),
            new Restaurant("���������������� ���",
                "������������� ��������, ��� ��� ���� ������ ��������� ������ � ������������ ���������� �������.",
                "Ukraine", "Kiev"),
            new Restaurant("��������� ���������� ������",
                "�����, ��� ���������������� ����� ����������� � ������������� ���������, ����� ������� ������������ ����.",
                "Ukraine", "Kiev"),
            new Restaurant("���������� �����������",
                "��������, ��� ������ ����� - ��� ������������ ���������, ���������� � ���� ������������ � �������������� ����.",
                "Ukraine", "Kiev"),
            new Restaurant("������� ������",
                "����� ��� ��������, ������������ ������� ����� ���������� ���� � �������� ������.", "Ukraine",
                "Kiev"),
            new Restaurant("������ �������",
                "��������, ��� ���������� � ������ ����������� ����������� � ������, ���������� ��������� �������.",
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