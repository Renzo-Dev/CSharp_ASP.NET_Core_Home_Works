using Microsoft.AspNetCore.Mvc;

namespace Home_Work_14_MVC.Components;

public class GetCurrentTime : ViewComponent
{
    public string Invoke()
    {
        return $"Текущее время: {DateTime.Now.ToString("HH:mm:ss")}";
    }
}

public class GetCurrentDate : ViewComponent
{
    public string Invoke()
    {
        return $"Текущая дата: {DateTime.Now.ToString("M/d/yy")}";
    }
}

public class GetOsVersion : ViewComponent
{
    public string Invoke()
    {
        return $"Версия Windows: {Environment.OSVersion}";
    }
}

public class WeatherViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View(WeatherData._weatherData);
    }
}

public class WeatherData
{
    public static WeatherData _weatherData = new();
    public int Temperature = 25;
}

public class FeaturedProductsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var featuredProducts = GetFeaturedProductsFromDatabase();
        return View(featuredProducts);
    }

    private List<Product> GetFeaturedProductsFromDatabase()
    {
        // Логика для получения избранных продуктов из базы данных
        return new List<Product>
        {
            new() { Name = "Product 1", Price = "19.99M" },
            new() { Name = "Product 2", Price = "29.99M" },
            new() { Name = "Product 3", Price = "39.99M" }
        };
    }
}

public class Product
{
    public string Name;
    public string Price;

    public Product()
    {
    }

    public Product(string name, string price)
    {
        Name = name;
        Price = price;
    }
}