/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/using DAL.Model;

namespace DAL.Dao;

public interface IAlertDao
{
    public AlertDTO GetAlert(int idHardware);
    public bool CreateAlert(AlertDTO alertDTO);
    public bool DeleteAlert(int idHardware);
    public bool UpdateAlert(AlertDTO alertDTO);
    public Task AlertEvent(AlertDTO alert);
    public AlertDTO? CheckAlert(int actualValue, int idHardware);
}
