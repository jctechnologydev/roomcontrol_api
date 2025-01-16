/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/

using Backend.Model;
using DAL.Dao;
using DAL.Model;
using Npgsql;

namespace DB.Dao;

public class StateDao : IStateDao
{

    /// <summary>
    /// Busca de todos os estados que um hardware pode ter
    /// </summary>
    /// <returns></returns>
    public List<StateDTO> GetAllState()
    {
        List<StateDTO> states = new List<StateDTO>();
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "State";
                string idStateCol = "idState";
                string nameCol = "name";
                using (var command = new NpgsqlCommand($"SELECT \"{idStateCol}\", \"{nameCol}\" FROM \"{table}\"", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        StateDTO state = new StateDTO()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal(idStateCol)),
                            Name = reader.GetString(reader.GetOrdinal(nameCol))
                        };
                        states.Add(state);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return states;
        }catch
        {
            throw new Exception("State not found");
        }

    }

    public StateDTO GetState(int idState)
    {
        StateDTO state;
        using (var connection = DBHelp.DBConnection())
        {
            connection.Open();
            string table = "State";
            string idStateCol = "idState";
            string nameCol = "name";
            using (var command = new NpgsqlCommand($"SELECT \"{idStateCol}\", \"{nameCol}\" FROM \"{table}\" WHERE \"{idStateCol}\" = @IdState;", connection))
            {
                command.Parameters.AddWithValue("@IdState", idState);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    state = new StateDTO()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(idStateCol)),
                        Name = reader.GetString(reader.GetOrdinal(nameCol))
                    };
                }
                else
                {
                    reader.Close();
                    connection.Close();
                    throw new APIException(404, "Estado não encontrado");
                }

                reader.Close();
            }
            connection.Close();
        }

        return state;
    }

    public bool Add(StateDTO stateDto)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "State";
                string nameCol = "name";
                using (var command = new NpgsqlCommand($"INSERT INTO \"{table}\" (\"{nameCol}\") VALUES (@Name);", connection))
                {
                    command.Parameters.AddWithValue("@Name", stateDto.Name);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
            }
        }catch(Exception e)
        {
            throw e;
        }
    }
}