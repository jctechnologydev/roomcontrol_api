/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace Backend.Model;

public class ActuatorState
{
    private int id;
    private string state;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string State
    {
        get => state;
        set => state = value ?? throw new ArgumentNullException(nameof(value));
    }
}