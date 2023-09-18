using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CSharp_ASP_Net_MVC_Exam.Filters;

public class JwtAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Проверяем наличие JWT токена
        var jwtToken = context.HttpContext.Request.Cookies["AuthorizationJWT"]?.Replace("Bearer ", "");

        if (string.IsNullOrEmpty(jwtToken))
        {
            // Если токен отсутствует, перенаправляем пользователя на страницу входа
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Home",
                action = "Login"
            }));
        }
        // Здесь вы можете добавить логику проверки действительности JWT токена,
        // например, с использованием библиотеки System.IdentityModel.Tokens.Jwt.
        // Если токен действителен, можно позволить доступ к методу контроллера.
        // Если токен недействителен, также перенаправляем пользователя на страницу входа.
    }
}