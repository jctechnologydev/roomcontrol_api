/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace MQTT.Model;

public class ActuatorSetter
{
    private int id;
    private string operation;
    private string value;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Operation
    {
        get => operation;
        set => operation = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Value
    {
        get => value;
        set => this.value = value ?? throw new ArgumentNullException(nameof(value));
    }
}