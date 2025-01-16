/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace IPCA.Model;

public class UserSubject
{
    private int idUserSubject;
    private int idSubject;
    private int idUser;

    public int IdUserSubject
    {
        get => idUserSubject;
        set => idUserSubject = value;
    }

    public int IdSubject
    {
        get => idSubject;
        set => idSubject = value;
    }

    public int IdUser
    {
        get => idUser;
        set => idUser = value;
    }
}