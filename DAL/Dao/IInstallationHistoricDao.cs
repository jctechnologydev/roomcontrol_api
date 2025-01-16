/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using DAL.Model;

namespace DAL.Dao;

public interface IInstallationHistoricDao
{
    public List<InstallationHistoricDTO> GetAllInstallationHistoric();
    public bool CreateHistoric(int idHardware, int idRoom, int idUser);
    public bool DeleteHistoric(int idHardware);
    public int GetInstallationHistoricRoom(int idHardware);
}
