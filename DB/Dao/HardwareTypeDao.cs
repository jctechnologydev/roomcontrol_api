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

public class HardwareTypeDao : IHardwareTypeDao
{

    /// <summary>
    /// Busca na base de dados de todos tipos de Hardwares
    /// </summary>
    /// <returns>Retorna uma lista de Hardwares</returns>
    public List<HardwareTypeDTO> GetAllHardwareType()
    {
        List<HardwareTypeDTO> hardwareTypes = new List<HardwareTypeDTO>();
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "HardwareType";
                string idFuncionalityCol = "idHardware";
                string nameCol = "name";
                using (var command = new NpgsqlCommand($"SELECT \"{idFuncionalityCol}\", \"{nameCol}\" FROM \"{table}\"", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        HardwareTypeDTO hardwareType = new HardwareTypeDTO()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal(idFuncionalityCol)),
                            Name = reader.GetString(reader.GetOrdinal(nameCol))
                        };
                        hardwareTypes.Add(hardwareType);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return hardwareTypes;
        }catch
        {
            throw new APIException(404, "HardwareType not found");
        }
    }




    /// <summary>
    /// Pesquisar um Hardware pelo id do Hardware
    /// </summary>
    /// <param name="idHardwareType"></param>
    /// <returns>Retorna o tipo de hardware</returns>
    /// <exception cref="Exception"></exception>
    public HardwareTypeDTO GetHardwareType(int idHardware)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table1 = "Hardware";
                string table2 = "HardwareType";
                string idHardwareCol = "idHardware";
                string idHardwareTypeCol1 = "idHardwareType";
                string idHardwareTypeCol2 = "HardwareTypeidHardwareType";
                string nameCol = "name";

                string query = $"SELECT \"{table2}\".\"{idHardwareTypeCol1}\", \"{table2}\".{nameCol} " +
                    $"FROM public.\"{table1}\" inner join public.\"{table2}\" on \"{table2}\".\"{idHardwareTypeCol1}\" = \"{table1}\".\"{idHardwareTypeCol2}\"" +
                    $"and \"{idHardwareCol}\" = @IdHardware;";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                var reader = command.ExecuteReader();
                reader.Read();

                int idHardwareType = reader.GetInt32(reader.GetOrdinal(idHardwareTypeCol1));
                string name = reader.GetString(reader.GetOrdinal(nameCol));
                connection.Close();
                reader.Close();

                HardwareTypeDTO hardwareTypeDto = new HardwareTypeDTO()
                {
                    Id = idHardwareType,
                    Name = name
                };
                return hardwareTypeDto;
            }
        }
        catch
        {
            throw new Exception("HardwareType not found");
        }
    }

    public HardwareTypeDTO GetHardwareTypeById(int idHardwareType)
    {
        
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "HardwareType";
                string idHardwareTypeCol = "idHardwareType";
                string nameCol = "name";

                string query = $"SELECT \"{table}\".\"{idHardwareTypeCol}\", \"{table}\".{nameCol} " +
                               $"FROM public.\"{table}\" WHERE \"{table}\".\"{idHardwareTypeCol}\" = @IdHardwareType;";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardwareType", idHardwareType);
                var reader = command.ExecuteReader();
                reader.Read();

                int idHardwareTypeRes = reader.GetInt32(reader.GetOrdinal(idHardwareTypeCol));
                string name = reader.GetString(reader.GetOrdinal(nameCol));
                connection.Close();
                reader.Close();

                HardwareTypeDTO hardwareTypeDto = new HardwareTypeDTO()
                {
                    Id = idHardwareTypeRes,
                    Name = name
                };
                return hardwareTypeDto;
            }
        }
        catch
        {
            throw new Exception("HardwareType not found");
        }
    }

    public bool Add(HardwareTypeDTO hardwareType)
    {
        int rowsAffected = 0;
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "HardwareType";
                string nameCol = "name";

                string query = $"INSERT INTO public.\"{table}\"(\"{nameCol}\") " +
                               $"VALUES(@Name')";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", hardwareType.Name);
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

            return rowsAffected > 0;
        }      
        catch
        {
            throw new Exception("HardwareType not created");
        }
    }

    /// <summary>
    /// Pesquisa se um Hardware existe na base de dados
    /// </summary>
    /// <param name="idHardwareType"></param>
    /// <returns>Retorna verdade ou falso</returns>
    /// <exception cref="Exception"></exception>
    public bool ExistsHardwareType(int idHardwareType)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "HardwareType";
                string idHardwareTypeCol = "idHardwareType";
                string nameCol = "name";
                string comma = ",";
                string pleas = "'";
                string qMarks = "\"";

                string query = $"SELECT * FROM public. {qMarks}{table}{qMarks} " +
                    $"WHERE {qMarks}{idHardwareTypeCol}{qMarks} = @IdHardwareType;";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardwareType", idHardwareType);
                var reader = command.ExecuteReader();
                reader.Read();

                int read = reader.GetInt32(0);
                connection.Close();
                reader.Close();
                return read == idHardwareType;
            }
        }
        catch
        {
            throw new Exception("HardwareType not found");
        }
    }
}
