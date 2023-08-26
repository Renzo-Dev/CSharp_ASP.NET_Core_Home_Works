namespace Home_Work_7;

public class User
{
    public User(string login, string password, string email)
    {
        this.login = login;
        this.password = password;
        this.email = email;
    }

    public User()
    {
    }

    public string login { get; set; }
    public string password { get; set; }
    public string email { get; set; }
}

public static class Users
{
    public static List<User> _users = new();
}