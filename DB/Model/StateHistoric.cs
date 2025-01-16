/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace DB.Model;

internal class StateHistoric
{
    #region attributes
    private DateTime registrationDate;
    private int idHardware;
    private int idState;
    #endregion

    #region properties
    public DateTime RegistrationDate
    {
        get => registrationDate;
        set => registrationDate = value;
    }

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
    #endregion
}