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
        var result = $"<h2>{Environment.OSVersion}</h2>";
        return new HtmlString(result);
    }
}