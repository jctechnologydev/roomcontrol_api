/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace DAL.Model;

public class DataDTO
{
    #region Attributes
    private int id;
    private int idHardware;
    private int idDataType;
    private string value;
    private DateTime registrationDate;
    #endregion

    #region Properties

    public int Id
    {
        get => id;
        set => id = value;
    }

    public int IdHardware
    {
        get => idHardware;
        set => idHardware = value;
    }

    public int IdDataType
    {
        get => idDataType;
        set => idDataType = value;
    }

    public string Value
    {
        get => value;
        set => this.value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime RegistrationDate
    {
        get => registrationDate;
        set => registrationDate = value;
    }
    #endregion
}




