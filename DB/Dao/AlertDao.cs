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
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using IPCA;
using IPCA.Model;
using Npgsql;

namespace DB.Dao;

public class AlertDao : IAlertDao
{
    // Guarda os tokens já utilizados para não fazer outro createFirebase
    private static bool firebaseAppCreate = false;

    private readonly IHardwareTypeDao _hardwareTypeDao;
    private readonly IInstallationHistoricDao _installationHistoricDao;

    /// <summary>
    /// Construtor vázio
    /// </summary>
    public AlertDao() { }

    /// <summary>
    /// Construtor para injeção de dependências
    /// </summary>
    /// <param name="hardwareTypeDao"></param>
    /// <param name="installationHistoricDao"></param>
    public AlertDao(IHardwareTypeDao hardwareTypeDao, IInstallationHistoricDao installationHistoricDao)
    {
        _hardwareTypeDao = hardwareTypeDao;
        _installationHistoricDao = installationHistoricDao;
    }


    /// <summary>
    /// Função que faz a busca de todos alertas na base de dados
    /// </summary>
    /// <returns>Retorna uma lista de alertas</returns>
    public List<AlertDTO> GetAllAlert()
    {
        List<AlertDTO> alerts = new List<AlertDTO>();
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Alert";
                string idHardwareCol = "idHardware";
                string maxValue = "maxValue";
                string minValue = "minValue";
                string nameCol = "name";
                using (var command = new NpgsqlCommand($"SELECT \"{idHardwareCol}\", \"{nameCol}\", \"{maxValue}\" , \"{minValue}\" FROM \"{table}\"", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AlertDTO alert = new AlertDTO()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal(idHardwareCol)),
                            MaxValue = reader.GetInt32(reader.GetOrdinal(maxValue)),
                            MinValue = reader.GetInt32(reader.GetOrdinal(minValue)),
                        };
                        alerts.Add(alert);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return alerts;
        }
        catch
        {
            throw new APIException(404, "Alert not found");
        }
    }

    /// <summary>
    /// Função de faz a busca de um alerta por id
    /// </summary>
    /// <param name="idHardware">id do hardware</param>
    /// <returns>Retorna verdade ou falso</returns>
    public AlertDTO GetAlert(int idHardware)
    {
        AlertDTO alertDto = null;
       
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Alert";
                string idHardwareCol = "HardwareidHardware";
                string maxValue = "maxValue";
                string minValue = "minValue";

                string query = $"SELECT \"{idHardwareCol}\",\"{maxValue}\",\"{minValue}\" " +
                                $"FROM public.\"{table}\" " +
                                $"WHERE \"{idHardwareCol}\" = @IdHardware";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(reader.GetOrdinal(idHardwareCol)) == idHardware)
                    {
                        alertDto = new AlertDTO()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal(idHardwareCol)),
                            MinValue = reader.GetInt32(reader.GetOrdinal(minValue)),
                            MaxValue = reader.GetInt32(reader.GetOrdinal(maxValue))
                        };
                    }                  
                }
                reader.Close();
                connection.Close();

                return alertDto;
            
        }
    }



    /// <summary>
    /// Função para criar alerta
    /// </summary>
    /// <param name="alertDTO">objeto alertDto</param>
    /// <returns>Retorna verdade ou falso</returns>
    public bool CreateAlert(AlertDTO alertDTO)
    {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Alert";
                string idHardwareCol = "HardwareidHardware";
                string minValueCol = "minValue";
                string maxValueCol = "maxValue";


                string query = $"INSERT INTO public.\"{table}\"(\"{idHardwareCol}\"," +
                                $"\"{maxValueCol}\",\"{minValueCol}\") " +
                                $"VALUES(@Id, @Max, @Min)";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", alertDTO.Id);
                command.Parameters.AddWithValue("@Max", alertDTO.MaxValue);
                command.Parameters.AddWithValue("@Min", alertDTO.MinValue);
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
    }

    /// <summary>
    /// Função que verifica se o alerta ultrapassou os limites permitidos ou não.
    /// </summary>
    /// <param name="actualValue">valor atual do sensor</param>
    /// <param name="idHardware">id do hardware</param>
    /// <returns>Retorna objeto alertDto</returns>
    public AlertDTO? CheckAlert(int actualValue, int idHardware)
    {
        try
        {
            AlertDTO? alert = GetAlert(idHardware);

            if (alert == null || (alert.MinValue < actualValue && alert.MaxValue > actualValue))
                alert = null;
            return alert;
            
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    /// <summary>
    /// Função que cria uma messagem, para o envio de notificações aos utilizadores
    /// </summary>
    /// <param name="idHardware">id do hardware</param>
    /// <param name="actualValue">valor actual do sensor</param>
    /// <param name="title">título da mensagem a ser enviada</param>
    /// <returns>Retorna task Message</returns>
    public async Task<Message> CreateMessage(int idHardware, int actualValue)
    {

        try
        {
            HardwareTypeDTO typeHardware = _hardwareTypeDao.GetHardwareType(idHardware);
            int idRoom = _installationHistoricDao.GetInstallationHistoricRoom(idHardware);
            Classroom room = await RepositoryFactory.GetClassroomRepository().GetClassroom(idRoom);

            string response = string.Empty;
            string title = "Alerta";
            string description = $"O Sensor de {typeHardware.Name} na {room.Name} utltrapassou os limites permitidos, atualmente a {typeHardware.Name} é {actualValue}";

            Message message = new Message()
            {
                Notification = new Notification()
                {
                    Title = title,
                    Body = description,
                },
               Topic = "ALERT"
        };
            return message;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }

    /// <summary>
    /// Função para envio de notificações aos utilizadores android
    /// </summary>
    /// <param name="alert">objeto alert</param>
    /// <returns>Task</returns>
    /// <exception cref="Exception"></exception>
    public async Task AlertEvent(AlertDTO alert)
    {
        try
        {
                Message message = await CreateMessage(alert.Id, alert.ActualValue);
                String GOOGLE_APPLICATION_CREDENTIALS_PATH = @"smartrooms-372021-firebase-adminsdk-m1cne-8cbec2a90d.json";

                if (firebaseAppCreate == false)
                {
                    FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromFile(GOOGLE_APPLICATION_CREDENTIALS_PATH),
                    });
                    firebaseAppCreate = true;
                }
                string response = string.Empty;
                await FirebaseMessaging.DefaultInstance.SendAsync(message);
            
        }
        catch (FirebaseException fb)
        {
            throw new Exception(fb.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


   /// <summary>
   /// Função para atulizar um alerta
   /// </summary>
   /// <param name="alertDTO"></param>
   /// <returns>Retorna verdade ou falso</returns>
    public bool UpdateAlert(AlertDTO alertDTO)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Alert";
                string idHardwareCol = "HardwareidHardware";
                string minValueCol = "minValue";
                string maxValueCol = "maxValue";

                string query = $"UPDATE public.\"{table}\" " +
                               $"SET \"{minValueCol}\" = @Min," +
                               $"\"{maxValueCol}\" = @Max" +
                               $" WHERE \"{idHardwareCol}\" = @Id";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", alertDTO.Id);
                command.Parameters.AddWithValue("@Min", alertDTO.MinValue);
                command.Parameters.AddWithValue("@Max", alertDTO.MaxValue);
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
        }
        catch
        {
            throw new Exception("Something went wrong updating the record");
        }
    }

    /// <summary>
    /// Função para eliminar um alerta
    /// </summary>
    /// <param name="idHardware">id do hardware</param>
    /// <returns>Retorna verdade ou falso</returns>
    /// <exception cref="Exception"></exception>
    public bool DeleteAlert(int idHardware)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Alert";
                string idHardwareCol = "HardwareidHardware";
                string query = $"DELETE FROM public.\"{table}\" " +
                                $"WHERE \"{idHardwareCol}\" = @Id";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", idHardware);
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
        }
        catch
        {
            throw new Exception("Something went wrong deleting the record");
        }
    }
}