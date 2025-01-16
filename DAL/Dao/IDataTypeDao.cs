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

public interface IDataTypeDao
{
    public DataTypeDTO GetDataTypeByShortTypeName(string shortName);
    public bool CreateDataType(DataTypeDTO data);
    public List<DataTypeDTO> GetAllDataType();
    public bool DeleteTypeData(int idHardware);

}