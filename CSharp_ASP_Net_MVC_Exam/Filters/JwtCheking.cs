using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CSharp_ASP_Net_MVC_Exam.Filters;

public class JwtCheking : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Проверяем наличие JWT токена
        var jwtToken = context.HttpContext.Request.Cookies["AuthorizationJWT"]?.Replace("Bearer ", "");

        if (!string.IsNullOrEmpty(jwtToken))
            // Если токен отсутствует, перенаправляем пользователя на страницу входа
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Home",
                action = "Index"
            }));
    }
}