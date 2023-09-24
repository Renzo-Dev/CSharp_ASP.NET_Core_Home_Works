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
        // else
        // {
        //     
        // }

        // добавить логику проверки действительности JWT токена,
        // Если токен действителен, дать доступ к методу контроллера, перенаправить на страницу чата ( с пользовательскими данными ).
        // Если токен недействителен, перенаправить пользователя на страницу входа.
    }
}