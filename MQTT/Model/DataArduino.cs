namespace MQTT.Model;

public class DataArduino
{
    private int _idRoom;
    private int _idDataType;
    private int _idHardware;
    private string value;

    public int IdRoom
    {
        get => _idRoom;
        set => _idRoom = value;
    }

    public int IdDataType
    {
        get => _idDataType;
        set => _idDataType = value;
    }

    public int IdHardware
    {
        get => _idHardware;
        set => _idHardware = value;
    }

    public string Value
    {
        get => value;
        set => this.value = value ?? throw new ArgumentNullException(nameof(value));
    }
}