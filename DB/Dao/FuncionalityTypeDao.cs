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

public class FuncionalityTypeDao : IFuncionalityTypeDao
{

    /// <summary>
    /// Método que faz a busca de todas funcionalidades na base de dados
    /// </summary>
    /// <returns>Retorna uma lista de funcionalidades</returns>
    public List<FuncionalityTypeDTO> GetAllFuncionality()
    {
        List<FuncionalityTypeDTO> funcionalityTypes = new List<FuncionalityTypeDTO>();
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "FuncionalityType";
                string idFuncionalityCol = "idFuncionality";
                string nameCol = "name";
                using (var command = new NpgsqlCommand($"SELECT \"{idFuncionalityCol}\", \"{nameCol}\" FROM \"{table}\"", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FuncionalityTypeDTO funcionalityType = new FuncionalityTypeDTO()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal(idFuncionalityCol)),
                            Name = reader.GetString(reader.GetOrdinal(nameCol))
                        };
                        funcionalityTypes.Add(funcionalityType);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return funcionalityTypes;
        }catch
        {
            throw new APIException(404, "FucionalityType not found on database");
        }
    }

    /// <summary>
    /// Método que pesquisa se uma funcionalidade existe
    /// </summary>
    /// <param name="idFuncionality">id da funcionalidade</param>
    /// <returns>Retorna verdade ou falso</returns>
    /// <exception cref="Exception"></exception>
    public bool ExistsFuncionality(int idFuncionality)
    {
        using (var connection = DBHelp.DBConnection())
        {
            try
            {
                connection.Open();
                string table = "FuncionalityType";
                string idHardwareTypeCol = "idFuncionality";
                string nameCol = "name";
                string comma = ",";
                string pleas = "'";
                string qMarks = "\"";

                string query = $"SELECT * FROM public.\"{table}\" " +
                                $"WHERE \"{idHardwareTypeCol}\" = @IdFuncionality";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdFuncionality", idFuncionality);
                var reader = command.ExecuteReader();

                reader.Read();
                int read = reader.GetInt32(reader.GetOrdinal(idHardwareTypeCol));
                connection.Close();
                reader.Close();
                return read == idFuncionality;
            }catch {
                throw new Exception("FuncionalityType not found on database");
            }
        }
    }

    public bool Add(FuncionalityTypeDTO funcionalityType)
    {
        
        int rowsAffected = 0;
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "FuncionalityType";
                string nameCol = "name";

                string query = $"INSERT INTO public.\"{table}\"(\"{nameCol}\") " +
                               $"VALUES(@Name)";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", funcionalityType.Name);
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

            return rowsAffected > 0;
        }      
        catch
        {
            throw new Exception("FuncionalityType not created");
        }
    }

    public FuncionalityTypeDTO GetById(int idFuncionalityType)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "FuncionalityType";
                string idFuncionalityCol = "idFuncionality";
                string nameCol = "name";

                string query = $"SELECT \"{table}\".\"{nameCol}\" FROM public.\"{table}\" where public.\"{table}\".\"{idFuncionalityCol}\" = @IdFuncionalityType";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdFuncionalityType", idFuncionalityType);
                var reader = command.ExecuteReader();
                reader.Read();

                string read = reader.GetString(reader.GetOrdinal(nameCol));
                connection.Close();
                reader.Close();

                FuncionalityTypeDTO funcionalityType = new FuncionalityTypeDTO()
                {
                    Id = idFuncionalityType,
                    Name = read
                };
                return funcionalityType;
            }
        }
        catch
        {
            throw new Exception("Funcionality Type not found");
        }
    }
}