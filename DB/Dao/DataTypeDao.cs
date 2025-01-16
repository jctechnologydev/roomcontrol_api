/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/

using Backend.Model;
using DAL;
using DAL.Dao;
using DAL.Model;
using Npgsql;

namespace DB.Dao;


public class DataTypeDao : IDataTypeDao
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortName"></param>
    /// <returns></returns>
    public DataTypeDTO GetDataTypeByShortTypeName(string shortName)
    {
        DataTypeDTO dataTypeDTO = null;

        using (var connection = DBHelp.DBConnection())
        {
            connection.Open();
            string table = "DataType";
            string idDataTypeCol = "idDataType";
            string nameCol = "name";

            string query = $"SELECT \"{idDataTypeCol}\", {nameCol} " +
                            $"FROM public.\"{table}\" " +
                            $"WHERE {nameCol} LIKE @shortName";

            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@shortName", shortName + "%");
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                dataTypeDTO = new DataTypeDTO()
                {
                    Id = reader.GetInt32(reader.GetOrdinal(idDataTypeCol)),
                    Name = reader.GetString(reader.GetOrdinal(nameCol)),
                };
            }
            reader.Close();
            connection.Close();

            return dataTypeDTO;
        }
    }
    

    /// <summary>
    /// Busca dos tipos de dados
    /// </summary>
    /// <returns>Retorna uma lista de tipos de dados</returns>
    public List<DataTypeDTO> GetAllDataType()
    {
        List<DataTypeDTO> dataTypes = new List<DataTypeDTO>();
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "DataType";
                string idDataTypeCol = "idDataType";
                string nameCol = "name";
                using (var command = new NpgsqlCommand($"SELECT \"{idDataTypeCol}\",\"{nameCol}\" FROM \"{table}\"", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DataTypeDTO dataType = new DataTypeDTO()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal(idDataTypeCol)),
                            Name = reader.GetString(reader.GetOrdinal(nameCol))
                        };
                        dataTypes.Add(dataType);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return dataTypes;
        }catch
        {
            throw new APIException(404, "DataType not found on database");
        }
    }

    /// <summary>
    /// Função pra inserir o tipo de dado (ºC, K ou F)
    /// </summary>
    /// <param name="data">objeto DataType</param>
    /// <returns>Retorna verdade ou falso</returns>
    /// <exception cref="Exception"></exception>
    public bool CreateDataType(DataTypeDTO data)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "DataType";
                string idDataTypeCol = "idDataType";
                string nameCol = "name";
                string registrationDateCol = "registrationDate";

                string query = $"INSERT INTO public.\"{table}\"(\"{nameCol}\") " +
                                $"VALUES(@Name)";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", data.Name);
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
        }
        catch
        {
            throw new Exception("Data not created");
        }
    }

    /// <summary>
    /// Função para eliminar um tipo de dado
    /// </summary>
    /// <param name="idHardware">id do utilizador</param>
    /// <returns>retorna verdade ou falso</returns>
    /// <exception cref="Exception"></exception>
    public bool DeleteTypeData(int idHardware)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Data";
                string idDataCol = "idData";
                string idHardwareCol = "HardwareidHardware";
                string query = $"DELETE FROM public.\"{table}\" " +
                                $"WHERE \"{idHardwareCol}\" = @Id";

                Console.Write(query);
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", idHardware);
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
        }
        catch
        {
            throw new Exception("Something went wrong when deleting the record DataType");
        }
    }
}