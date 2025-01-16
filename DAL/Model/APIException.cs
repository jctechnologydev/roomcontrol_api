namespace Backend.Model;

public class APIException : Exception
{
    private int code;
    private string message;

    public int Code
    {
        get => code;
        set => code = value;
    }

    public string Message
    {
        get => message;
        set => message = value ?? throw new ArgumentNullException(nameof(value));
    }

    public APIException(int code, string message)
    {
        this.code = code;
        this.message = message;
    }
}