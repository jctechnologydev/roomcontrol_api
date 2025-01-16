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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace DB.Dao;

public class HardwareDao : IHardwareDao
{
    private readonly IHardwareTypeDao _hardwareTypeDao;
    private readonly IFuncionalityTypeDao _funcionalityTypeDao;
    private readonly IAlertDao _alertDao;
    private readonly IInstallationHistoricDao _installationHistoricDao;
    private readonly IDataDao _dataDao;

    /// <summary>
    /// Construtor vazio
    /// </summary>
    public HardwareDao() { }

    /// <summary>
    /// Construtor para injeção de dependências
    /// </summary>
    /// <param name="hardwareDao">interface HardwareDao</param>
    /// <param name="hardwareTypeDao">interface hardwareTypeDao</param>
    /// <param name="funcionalityTypeDao">interface funcionalityTypeDao</param>
    /// <param name="alertDao">interface alertDao</param>
    /// <param name="installationHistoricDao">interface installationHistoricDao</param>
    /// <param name="dataDao">interface dataDao</param>
    public HardwareDao(IHardwareTypeDao hardwareTypeDao, IFuncionalityTypeDao funcionalityTypeDao, 
            IAlertDao alertDao, IInstallationHistoricDao installationHistoricDao, IDataDao dataDao){
        _hardwareTypeDao = hardwareTypeDao;
        _funcionalityTypeDao = funcionalityTypeDao;
        _alertDao = alertDao;
        _installationHistoricDao = installationHistoricDao;
        _dataDao = dataDao;
    }


    /// <summary>
    /// Função que faz a busca de todos sensores lista de sensores
    /// </summary>
    /// <returns></returns>
    public List<HardwareDTO> GetAllHardware()
    {
        List<HardwareDTO> hardwares = new List<HardwareDTO>();
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Hardware";
                string idHardwareCol = "idHardware";
                string idHardwareTypeCol = "HardwareTypeidHardwareType";
                string typeFuncionalityCol = "FuncionalityTypeidFunctionality";
                string nameCol = "name";

                string query = $"SELECT \"{idHardwareCol}\",\"{idHardwareTypeCol}\",\"{typeFuncionalityCol}\", {nameCol} " +
                                $"FROM public.\"{table}\" ";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        HardwareDTO hardwareDTO = new HardwareDTO()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal(idHardwareCol)),
                            FuncionalityType = _funcionalityTypeDao.GetById(reader.GetInt32(reader.GetOrdinal(typeFuncionalityCol))),
                            HardwareType = _hardwareTypeDao.GetHardwareTypeById(reader.GetInt32(reader.GetOrdinal(idHardwareTypeCol))),
                            Name = reader.GetString(reader.GetOrdinal(nameCol))
                        };
                        hardwares.Add(hardwareDTO);
                    }
                    reader.Close();

                    connection.Close();

                    return hardwares;
                }
            }
        }
        catch
        {
            throw new APIException(404, "Hardware not found");
        }
    }

    /// <summary>
    /// Função que faz a busca dos hardwares de uma determinada sala
    /// </summary>
    /// <param name="idRoom">id da sala</param>
    /// <returns>Retorna uma lista de RoomDataDTO</returns>
    public List<RoomDataDTO> GetHardwareRoom(int idRoom)
    {

        List<RoomDataDTO> roomsData = new List<RoomDataDTO>();

        using (var connection = DBHelp.DBConnection())
        {
            connection.Open();
            #region query
            string tableHardware = "Hardware";
            string tableState = "State";
            string tableStateHistoric = "StateHistoric";
            string tableInstallationHistoric = "InstallationHistoric";
            string tableDataType = "DataType";
            string tableData = "Data";
            string idHardwareCol = "idHardware";
            string idRoomCol = "idRoom";
            string valueCol = "value";
            string nameCol = "name";
            string idDataTypeCol = "idDataType";
            string dataTypeNameCol = "dataTypeName";
            string HardwareidHardware = "HardwareidHardware";


            string query = $"Select \"{tableHardware}\".\"{idHardwareCol}\", \"State\".{nameCol},\"{tableInstallationHistoric}\".\"{idRoomCol}\", \"{tableData}\".\"{valueCol}\", \"{tableDataType}\".\"{nameCol}\" AS \"{dataTypeNameCol}\"" +
                           $"From \"{tableHardware}\"" +
                           $"inner join \"{tableStateHistoric}\" on \"{tableHardware}\".\"idHardware\" = \"{tableStateHistoric}\".\"HardwareidHardware\"" +
                           $"inner join \"{tableState}\" on \"{tableState}\".\"idState\" = \"{tableStateHistoric}\".\"StateidState\"" +
                           $"inner join \"{tableInstallationHistoric}\" on \"{tableInstallationHistoric}\".\"HardwareidHardware\" = \"{tableHardware}\".\"idHardware\"" +
                           $"inner join \"{tableData}\" on \"{tableData}\".\"HardwareidHardware\" = \"{tableHardware}\".\"idHardware\"" +
                           $"inner join \"{tableDataType}\" on \"{tableDataType}\".\"{idDataTypeCol}\" = \"{tableData}\".\"{idDataTypeCol}\"" +
                           $" and \"{tableData}\".\"registrationDate\" = (" +
                                    $"select max(\"{tableData}\".\"registrationDate\")" +
                                    $"from \"{tableData}\"  where \"{tableData}\".\"HardwareidHardware\" = \"{tableHardware}\".\"idHardware\")" +
                           $"and \"{tableStateHistoric}\".\"registrationDate\" = (" +
                                    $"select max(\"{tableStateHistoric}\".\"registrationDate\")" +
                                    $"From \"{tableStateHistoric}\" where \"{tableStateHistoric}\".\"{HardwareidHardware}\" = \"{tableHardware}\".\"{idHardwareCol}\" and \"{tableInstallationHistoric}\".\"{idRoomCol}\" = @IdRoom)";
            #endregion

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdRoom", idRoom);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RoomDataDTO roomDTO = new RoomDataDTO()
                    {
                        Hardware = GetHardware(reader.GetInt32(reader.GetOrdinal(idHardwareCol))),
                        IdRoom = reader.GetInt32(reader.GetOrdinal(idRoomCol)),
                        Value = reader.GetString(reader.GetOrdinal(valueCol)),
                        State = reader.GetString(reader.GetOrdinal(nameCol)),
                        DataTypeName = reader.GetString(reader.GetOrdinal(dataTypeNameCol))
                    };
                    roomsData.Add(roomDTO);
                }
                reader.Close();

                connection.Close();

                return roomsData;
            }
        }
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="idHardware"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool ExistsHardware(int idHardware)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Hardware";
                string idHardwareCol = "idHardware";
                string nameCol = "name";

                string query = $"SELECT \"{idHardwareCol}\" " +
                                $"FROM public.\"{table}\"" +
                                $" WHERE  \"{idHardwareCol}\" = @IdHardware;";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                var reader = command.ExecuteReader();
                reader.Read();

                int read = reader.GetInt32(reader.GetOrdinal(idHardwareCol));
                connection.Close();
                reader.Close();
                return read == idHardware;

            }
        }
        catch(Exception ex)
        {
            throw new Exception("Hardware Not Found "+ ex.Message);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="idHardware"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public HardwareDTO GetHardware(int idHardware)
    {
        if (!ExistsHardware(idHardware))
        {
            throw new Exception();
        }
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Hardware";
                string idHardwareCol = "idHardware";
                string idHardwareTypeCol = "HardwareTypeidHardwareType";
                string typeFuncionalityCol = "FuncionalityTypeidFunctionality";
                string nameCol = "name";

                // Antes de atualizar um Hardware verificar se existe
                // Verificar se a funcionalidade exise
                //
                string query = $"SELECT \"{idHardwareCol}\",\"{idHardwareTypeCol}\",\"{typeFuncionalityCol}\",{nameCol } " +
                                 $"FROM public.\"{table}\" " +
                                 $"WHERE  \"{idHardwareCol}\"  = @IdHardware;";

                Console.WriteLine(query);
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                var reader = command.ExecuteReader();
                reader.Read();

                if (reader.GetInt32(reader.GetOrdinal(idHardwareCol)) == idHardware)
                {
                    HardwareDTO hardware = new HardwareDTO()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(idHardwareCol)),
                        Name = reader.GetString(reader.GetOrdinal(nameCol)),
                        HardwareType = _hardwareTypeDao.GetHardwareTypeById(reader.GetInt32(reader.GetOrdinal(idHardwareTypeCol))),
                        FuncionalityType = _funcionalityTypeDao.GetById(reader.GetInt32(reader.GetOrdinal(typeFuncionalityCol)))

                    };
                    connection.Close();
                    reader.Close();
                    return hardware;
                }
                reader.Close();
                connection.Close();


            }
            return null;
        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }



    /// <summary>
    /// Função para criar hardware
    /// </summary>
    /// <param name="createHardware"> objeto hardware</param>
    /// <param name="alertObj">objeto alerta</param>
    /// <param name="idRoom">id da sala</param>
    /// <param name="idUser">id do utilizador "Técnico"</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool CreateHardware(HardwareDTO createHardware, AlertDTO alertObj, int idRoom, int idUser)
    {
        _hardwareTypeDao.ExistsHardwareType(createHardware.HardwareType.Id);
        _funcionalityTypeDao.ExistsFuncionality(createHardware.HardwareType.Id);
       
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Hardware";
                string idHardwareCol = "idHardware";
                string idHardwareTypeCol = "HardwareTypeidHardwareType";
                string typeFuncionality = "FuncionalityTypeidFunctionality";
                string nameCol = "name";

                string query = $"INSERT INTO public.\"{table}\"(\"{idHardwareTypeCol}\"," +
                                $"\"{typeFuncionality}\",{nameCol}) " +
                                $"VALUES(@HardwareTypeId,@FuncionalityTypeId,\'@Name\')" +
                                $"RETURNING \"{idHardwareCol}\"";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@HardwareTypeId", createHardware.HardwareType.Id);
                command.Parameters.AddWithValue("@FuncionalityTypeId", createHardware.FuncionalityType.Id);
                command.Parameters.AddWithValue("@Name", createHardware.Name);
                command.ExecuteNonQuery();

                //Console.WriteLine(command.Parameters[idHardware].Value);
                var reader = command.ExecuteReader();
                reader.Read();

                int idHardware = reader.GetInt32(reader.GetOrdinal(idHardwareCol));
                reader.Close();
                connection.Close();
                alertObj.Id = idHardware;
                bool alert = _alertDao.CreateAlert(alertObj);
                bool historic = _installationHistoricDao.CreateHistoric(idHardware, idRoom, idUser);
                return true;

            }
        }      
        catch
        {
            throw new Exception("Hardware not created");
        }
        
    }

    /// <summary>
    /// Função para atualizar hardware
    /// </summary>
    /// <param name="updateHardware"></param>
    /// <param name="alertDTO"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public bool UpdateHardware(HardwareDTO updateHardware, AlertDTO alertDTO)
    {
        try
        {

            if (!ExistsHardware(updateHardware.Id))
            {
                throw new APIException(404, "Hardware not found");
            }

            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Hardware";
                string idHardwareCol = "idHardware";
                string nameCol = "name";
                string query = $"UPDATE public.\"{table}\" " +
                               $"SET {nameCol} = \'@Name\'" +
                               $" WHERE \"{idHardwareCol}\" = @Id";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", updateHardware.Name);
                command.Parameters.AddWithValue("@Id", updateHardware.Id);
                command.ExecuteNonQuery();
                connection.Close();

                return _alertDao.UpdateAlert(alertDTO);
            }
        }catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createHardware"></param>
    /// <returns></returns>
    public bool DeleteHardware(int idHardware)
    {
        try
        {
            var hardwareObj = GetHardware(idHardware);
            _alertDao.DeleteAlert(hardwareObj.Id);
            _dataDao.DeleteData(hardwareObj.Id);
            _installationHistoricDao.DeleteHistoric(hardwareObj.Id);

            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Hardware";
                string idHardwareCol = "idHardware";
                string nameCol = "name";

                string query = $"DELETE FROM public.\"{table}\"" +
                                $" WHERE \"{idHardwareCol}\" = @IdHardware";

                Console.Write(query);
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
        }
        catch
        {
            throw new Exception("Something went wrong when deleting the record Hardware");
        }
    }
}

