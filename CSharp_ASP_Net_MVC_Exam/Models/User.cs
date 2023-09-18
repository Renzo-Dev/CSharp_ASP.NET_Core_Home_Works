namespace CSharp_ASP_Net_MVC_Exam.Models;

public class User
{
    public User(string login, string password)
    {
        Login = login;
        Password = password;
        Guid = System.Guid.NewGuid().ToString();
    }

    public User()
    {
    }

    public string Login { get; set; }
    public string Password { get; set; }

    public string Guid { get; set; }
}