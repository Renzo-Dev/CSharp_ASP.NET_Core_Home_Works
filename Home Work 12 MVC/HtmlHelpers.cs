using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Home_Work_12_MVC;

public static class HtmlHelpers
{
    public static HtmlString GetTime(this IHtmlHelper html)
    {
        var result = $"<h2>Текущее время: {DateTime.Now.ToLongTimeString()}</h2>";
        return new HtmlString(result);
        // доделать 4 хелпера и 1 хелпер форму
    }

    public static HtmlString GetOsVersion(this IHtmlHelper html)
    {
        var result = $"<h2>Версия Windows: {Environment.OSVersion}</h2>";
        return new HtmlString(result);
    }

    public static HtmlString GetDayOfWeak(this IHtmlHelper html)
    {
        var result = $"<h2>Дань недели: {DateTime.Now.DayOfWeek}</h2>";
        return new HtmlString(result);
    }

    public static HtmlString GetUtc(this IHtmlHelper html)
    {
        var result = $"<h2>UTC: {DateTime.UtcNow}</h2>";
        return new HtmlString(result);
    }

    public static HtmlString GetUserName(this IHtmlHelper html)
    {
        var result = $"<h2>Иия пользователя: {Environment.UserName}</h2>";
        return new HtmlString(result);
    }

    public static HtmlString GetUserDomainName(this IHtmlHelper html)
    {
        var result = $"<h2>Имя домена: {Environment.UserDomainName}</h2>";
        return new HtmlString(result);
    }
}