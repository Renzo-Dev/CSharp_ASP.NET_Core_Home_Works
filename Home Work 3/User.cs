namespace Home_Work_3;

public class User
{
    public User(string guid, string? firstName, string? lastName, byte age, string? birthDay)
    {
        Guid = guid;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        BirthDate = birthDay;
    }

    public string Guid { get; set; }
    public string? FirstName { get; set; } // Имя
    public string? LastName { get; set; } // Фамилия
    public byte Age { get; set; } // возраст
    public string? BirthDate { get; set; }
}