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

public interface IDataDao
{
    public string ConverterTemperature(string valueIn, string typeIn, string typeOut);
    public List<DataDTO> GetAllData();
    public bool DeleteData(int idHardware);
    public void SaveData(DataDTO data);
}