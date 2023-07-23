namespace Home_Work_3;

public class Users
{
    readonly RequestDelegate next;

    public Users(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

    }
}