namespace Backend.Model.Request;

public class LoginDTO
{
    private string name;
    private string course;
    private string userType;
    private string token;
    private string imageUrl;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Course
    {
        get => course;
        set => course = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public string UserType
    {
        get => userType;
        set => userType = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Token
    {
        get => token;
        set => token = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ImageUrl
    {
        get => imageUrl;
        set => imageUrl = value ?? throw new ArgumentNullException(nameof(value));
    }
}