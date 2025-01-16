/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace DAL.Model;

public class HardwareTypeDTO
{
    # region Attributes
    private int id;
    private string name;
    #endregion

    #region Properties
    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }
    #endregion

}


