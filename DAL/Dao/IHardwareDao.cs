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

public interface IHardwareDao
{
    public List<HardwareDTO> GetAllHardware();
    public bool ExistsHardware(int idHardware);
    public HardwareDTO GetHardware(int idHardware);
    public bool CreateHardware(HardwareDTO createHardware, AlertDTO alertObj, int idRoom, int idUser);
    public bool DeleteHardware(int idHardware);
    public bool UpdateHardware(HardwareDTO updateHardware, AlertDTO alertDTO);
    public List<RoomDataDTO> GetHardwareRoom(int idRoom);
}