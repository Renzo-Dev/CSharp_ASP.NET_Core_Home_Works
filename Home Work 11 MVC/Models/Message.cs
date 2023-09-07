namespace Home_Work_10_MVC.Models;

public class Message
{
    public Message()
    {
    }

    public Message(string mes, string aut)
    {
        message = mes;
        author = aut;
    }

    public string? message { get; set; }
    public string? author { get; set; }
}