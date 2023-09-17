using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace Home_Work_15_MVC.Filters;

///
/// Глобальный фильтр прописан в Program.cs
///


// Логирует использование контролера или действия
public class LogActionFilter : IActionFilter
{
    private readonly ILogger<LogActionFilter> _logger;

    public LogActionFilter(ILogger<LogActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.RouteData.Values["controller"];
        var action = context.RouteData.Values["action"];
        var parameters = context.ActionArguments;

        _logger.LogInformation(
            $"Executing action '{action}' in controller '{controller}' with parameters: {string.Join(", ", parameters)}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Действия после выполнения метода контроллера
    }
}

// для установки HTTP-куки в ответе на запросы ( в данном случае ставит дату последнего запроса на сервер )
public class SetCookieAttribute : ActionFilterAttribute
{
    private readonly int _cookieExpires;
    private readonly string _cookieName;

    public SetCookieAttribute(string cookieName, int cookieExpires)
    {
        _cookieName = cookieName;
        _cookieExpires = cookieExpires;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (!context.HttpContext.Request.Cookies.ContainsKey(_cookieName))
        {
            // Получаем текущую дату и преобразуем ее в строку
            var currentDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(_cookieExpires), // Устанавливаем срок действия
                HttpOnly = true
            };

            context.HttpContext.Response.Cookies.Append(_cookieName, currentDate, cookieOptions);
        }
    }
}

// Используется для для добавления HTTP-заголовков к ответу
public class AddHeaderAttribute : ActionFilterAttribute
{
    private readonly string _name;
    private readonly string _value;

    public AddHeaderAttribute(string name, string value)
    {
        _name = name;
        _value = value;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        context.HttpContext.Response.Headers.Add(_name, _value);
        base.OnActionExecuted(context);
    }
}

public class BrowserInfoFilterAttribute : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ViewResult viewResult)
            viewResult.ViewData["UserAgent"] = context.HttpContext.Request.Headers["User-Agent"];
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Можете добавить логику, выполняемую перед отображением представления
    }
}

// ThrottlingFilter: Этот фильтр может использоваться для ограничения скорости запросов от одного клиента,
// чтобы предотвратить перегрузку сервера
// при многократном нажатии F5 / CTRL + R
public class ThrottlingFilter : IActionFilter
{
    private readonly IMemoryCache _cache;

    public ThrottlingFilter(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var clientIpAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
        var currentTime = DateTimeOffset.UtcNow;

        if (clientIpAddress != null && _cache.TryGetValue(clientIpAddress, out DateTimeOffset lastRequestTime))
        {
            // время которое прошло с последнего запроса клиента
            var timeElapsed = currentTime - lastRequestTime;
            // если прошло меньше 5 сек с посл. запроса
            if (timeElapsed < TimeSpan.FromSeconds(5))
                context.Result = new StatusCodeResult(StatusCodes.Status429TooManyRequests);
        }

        if (clientIpAddress != null) _cache.Set(clientIpAddress, currentTime, TimeSpan.FromSeconds(5));
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Ничего не делаем после выполнения действия
    }
}