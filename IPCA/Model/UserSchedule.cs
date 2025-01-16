/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace IPCA.Model;

public class UserSchedule
{
    private int idUserSubject;
    private int idSchedule;
    private int idCourse;
    private int idGrade;
    private int idClassRoom;

    public int IdUserSubject
    {
        get => idUserSubject;
        set => idUserSubject = value;
    }

    public int IdSchedule
    {
        get => idSchedule;
        set => idSchedule = value;
    }

    public int IdCourse
    {
        get => idCourse;
        set => idCourse = value;
    }

    public int IdGrade
    {
        get => idGrade;
        set => idGrade = value;
    }

    public int IdClassRoom
    {
        get => idClassRoom;
        set => idClassRoom = value;
    }
}