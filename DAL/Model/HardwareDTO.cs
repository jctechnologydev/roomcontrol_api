/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace DAL.Model;

public class HardwareDTO
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




