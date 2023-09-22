using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CSharp_ASP_Net_MVC_Exam.Filters;
using CSharp_ASP_Net_MVC_Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CSharp_ASP_Net_MVC_Exam.Controllers;

public class Home : Controller
{
    // временная БД
    public List<User> _users = new()
    {
        new User("Renzo", "Dan098dan")
    };

    [HttpGet]
    [TypeFilter(typeof(JwtAuthorizationFilter))]
    public IActionResult Index()
    {
        return View();
    }

    [Route("/Login")]
    [TypeFilter(typeof(JwtCheking))]
    public IActionResult Login()
    {
        ViewData["Title"] = "Login";
        return View();
    }

    // получаем данные для проверки , есть ли такой аккаунт, и валидны ли данные
    // елси данные валидны, генерируем JWT токен, отправляем его и переадрисовуем на главную страницу
    [HttpGet]
    public IActionResult Authentication(string? login, string? password)
    {
        if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
        {
            // проверяем учетные данные " потом поменять на БД "
            var user = _users.SingleOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                // Пользователь аутентифицирован, создаем JWT токен
                var token = GenerateJwtToken(user);

                Response.Cookies.Append("AuthorizationJWT", token, new CookieOptions
                {
                    HttpOnly = true, // защита от XSS атак
                    Expires = DateTime.UtcNow.AddMonths(1)
                });
                return Ok();
            }
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Sid, user.Guid)
        };

        var token = new JwtSecurityToken(AuthOptions.ISSUER, AuthOptions.AUDIENCE, claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}