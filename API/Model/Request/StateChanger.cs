namespace Backend.Model.Request;

public class StateChanger
{
    private int idHardware;
    private int idState;

    public int IdHardware
    {
        get => idHardware;
        set => idHardware = value;
    }

    public int IdState
    {
        get => idState;
        set => idState = value;
    }
}