namespace Home_Work_6;

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

    public string message { get; set; }
    public string author { get; set; }
}