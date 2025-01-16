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

/// <summary>
/// Histórico de instalação
/// </summary>
public class InstallationHistoricDao : IInstallationHistoricDao
{

    /// <summary>
    /// Busca na base de dados do histórico de instalação dos hardwares 
    /// </summary>
    /// <param name=""></param>
    /// <returns>Retorna uma lista do histórico</returns>
    public List<InstallationHistoricDTO> GetAllInstallationHistoric()
    {
        List<InstallationHistoricDTO> installationsHistorics = new List<InstallationHistoricDTO>();
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "InstallationHistoric";
                string idHardwareidHardwareCol = "HardwareidHardware";
                string nameCol = "name";
                using (var command = new NpgsqlCommand($"SELECT \"{idHardwareidHardwareCol}\", \"{nameCol}\" FROM \"{table}\"", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        InstallationHistoricDTO installationHistoric = new InstallationHistoricDTO()
                        {
                            IdHardware = reader.GetInt32(reader.GetOrdinal(idHardwareidHardwareCol)),
                            IdRoom = reader.GetInt32(reader.GetOrdinal(idHardwareidHardwareCol)),
                            IdUser = 1,
                            RegistrationDate = DateTime.Now
                        };
                        installationsHistorics.Add(installationHistoric);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return installationsHistorics;
        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


     /// <summary>
     /// Busca da última sala em que o Hardware foi instalado
     /// </summary>
     /// <param name="idHardware"></param>
     /// <returns>Retorna o id da sala</returns>
     /// <exception cref="Exception"></exception>
    public int GetInstallationHistoricRoom(int idHardware)
    {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table1 = "InstallationHistoric";
                string table2 = "Hardware";
                string idRoomCol = "idRoom";
                string idHardwareCol = "idHardware";
                string idHardwareidHardwareCol = "HardwareidHardware";
                string registrationDateCol = "registrationDate";

                string query = $"SELECT \"{table1}\".\"{idRoomCol}\" " +
                    $"FROM \"{table2}\" inner join \"{table1}\" " +
                    $"on \"{idHardwareidHardwareCol}\" = \"{idHardwareCol}\"" +
                    $"and \"{idHardwareidHardwareCol}\" = @IdHardware " +
                    $"and \"{registrationDateCol}\"= (select max(\"{registrationDateCol}\") from \"{table1}\"" +
                    $"where \"{idHardwareidHardwareCol}\" = @IdHardware);";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                var reader = command.ExecuteReader();
                int read = -1;
                if (reader.Read())
                {
                     read = reader.GetInt32(reader.GetOrdinal(idRoomCol));
                }                

                connection.Close();
                reader.Close();
                if (read == -1)
                    throw new APIException(404, "This hardware doesn´t have installation historic");
                return read;
            }
    }
  
    /// <summary>
    /// Função para criar histórico do hardware 
    /// Insere o histórico na base de dados
    /// </summary>
    /// <param name="idHardware"></param>
    /// <param name="idRoom"></param>
    /// <param name="idUser"></param>
    /// <returns></returns>
    public bool CreateHistoric(int idHardware, int idRoom, int idUser)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "InstallationHistoric";
                string idHardwareidHardwareCol = "HardwareidHardware";
                string idRoomCol = "idRoom";
                string registrationDateCol = "registrationDate";
                string idUserCol = "idUser";

                string query = $"INSERT INTO public.\"{table}\"(" +
                                $"\"{idHardwareidHardwareCol}\",\"{idRoomCol}\",\"" +
                                $"{registrationDateCol}\",\"{idUserCol}\") " +
                                $"VALUES(@IdHardware,@IdRoom,@Date,@IdUser)";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                command.Parameters.AddWithValue("@IdRoom", idRoom);
                command.Parameters.AddWithValue("@Date", DateTime.Now);
                command.Parameters.AddWithValue("@IdUser", idUser);

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
        }catch
        {
            throw new Exception("Installation historic not created");
        }

    }


    /// <summary>
    /// Função para eliminar histórico
    /// </summary>
    /// <param name="idHardware"></param>
    /// <returns>Retorna verdade ou falso</returns>
    /// <exception cref="Exception"></exception>
    public bool DeleteHistoric(int idHardware)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "InstallationHistoric";
                string idHardwareidHardwareCol = "HardwareidHardware";

                string query = $"DELETE FROM public.\"{table}\" WHERE \"{idHardwareidHardwareCol}\" = @IdHardware;";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
        }
        catch(Exception ex)
        {
            throw new Exception("Something went wrong deleting de record installation historic" + ex.Message);
        }
    }
}
