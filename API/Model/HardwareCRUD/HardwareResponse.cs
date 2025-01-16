using DAL.Model;

namespace Backend.Model.HardwareCRUD;

public class HardwareResponse
{
    # region Attributes
    private int id;
    private HardwareTypeDTO hardwareType;
    private FuncionalityTypeDTO funcionalityType;
    private string name;
    #endregion

    #region Properties
    public int Id
    {
        get => id;
        set => id = value;
    }

    public HardwareTypeDTO HardwareType
    {
        get => hardwareType;
        set => hardwareType = value ?? throw new ArgumentNullException(nameof(value));
    }

    public FuncionalityTypeDTO FuncionalityType
    {
        get => funcionalityType;
        set => funcionalityType = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }
    #endregion
}