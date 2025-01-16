/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace DB.Model;

internal class Alert
{
    #region attributes
    private int id;
    private int maxValue;
    private int minValue;
    #endregion

    #region properties
    public int Id
    {
        get => id;
        set => id = value;
    }

    public int MaxValue
    {
        get => maxValue;
        set => maxValue = value;
    }

    public int MinValue
    {
        get => minValue;
        set => minValue = value;
    }
    #endregion
}