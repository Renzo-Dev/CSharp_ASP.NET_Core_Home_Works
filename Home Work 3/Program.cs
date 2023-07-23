using Home_Work_3;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<Users>();

app.Run();