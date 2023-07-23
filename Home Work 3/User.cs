namespace Home_Work_3;

public class User
{
    public User(string guid, string? firstName, string? lastName, byte age, DateTime? birthDay)
    {
        Guid = guid;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        BirthDay = birthDay;
    }

    public void ChangeUserDate(string? firstName, string? lastName, byte age, DateTime? birthDay)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        BirthDay = birthDay;
    }

    public string Guid { get; set; }
    public string? FirstName { get; set; }  // Имя
    public string? LastName { get; set; }   // Фамилия
    public byte Age { get; set; }          // возраст
    public DateTime? BirthDay = null;
}