using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// builder.Services.AddAuthentication("Bearer").AddJwtBearer(); // добавляем сервис аутентификации
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // указывает, будет ли валидироваться издатель при валидации токена
        ValidateIssuer = true,
        // строка, представляющая издателя
        ValidIssuer = AuthOptions.ISSUER,
        // будет ли валидироваться потребитель токена
        ValidateAudience = true,
        // установка потребителя токена
        ValidAudience = AuthOptions.AUDIENCE,
        // будет ли валидироваться время существования
        ValidateLifetime = true,
        // установка ключа безопасности
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        // валидация ключа безопасности
        ValidateIssuerSigningKey = true
    };
}).AddCookie(options => { options.LoginPath = "/Login"; });

builder.Services.AddAuthorization(); // добавляем сервис авторизации
var app = builder.Build();


app.UseAuthentication(); // добавляем middleware аутентификации
app.UseAuthorization(); // добавляем middleware авторизации
app.UseStaticFiles();

// ROUTING 

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}"
);

app.MapControllerRoute(
    "Login",
    "Login",
    new { controller = "Home", action = "Login" }
);
app.MapControllerRoute(
    "Authentication",
    "Authentication",
    new { controller = "Home", action = "Authentication" }
);

app.MapControllerRoute(
    "Authentication",
    "Authentication",
    new { controller = "Home", action = "Registration" }
);

app.Run();


public class AuthOptions
{
    public const string ISSUER = "RenzoServer"; // издатель токена
    public const string AUDIENCE = "RenzoClient"; // потребитель токена
    private const string KEY = "к009jfd1mlimamflkm!afaflk"; // ключ для шифрации

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}