namespace Home_Work_7;

public class User
{
    public User(string login, string password, string email)
    {
        guid = Guid.NewGuid().ToString();
        this.login = login;
        this.password = password;
        this.email = email;
    }

    public User()
    {
    }

    public string guid { get; set; }
    public string login { get; set; }
    public string password { get; set; }
    public string email { get; set; }
}

public static class Users
{
    public static List<User> _users = new()
    {
        new User("Renzo", "Test", "Test@gmail.com"),
        new User("DiSpaCe", "Test", "Test@gmail.com"),
        new User("TheDarkReaper", "Test", "Test@gmail.com"),
        new User("PIPEC", "Test", "Test@gmail.com"),
    };
}