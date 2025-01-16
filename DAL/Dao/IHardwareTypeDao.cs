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

public interface IHardwareTypeDao
{
    public List<HardwareTypeDTO> GetAllHardwareType();
    public bool ExistsHardwareType(int idFuncionalityType);
    public HardwareTypeDTO GetHardwareType(int idHardware);
    public HardwareTypeDTO GetHardwareTypeById(int idHardware);
    public bool Add(HardwareTypeDTO hardwareType);
}