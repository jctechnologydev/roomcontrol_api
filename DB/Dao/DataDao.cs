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
using TemperatureConverter;
namespace DB.Dao;

public class DataDao : IDataDao
{
    private readonly IDataTypeDao _dataTypeDao;
    private IDataTypeDao dataTypeDao;

    public DataDao(IDataTypeDao dataTypeDao)
    {
        _dataTypeDao = dataTypeDao;
    }

    /// <summary>
    /// Função para busca de dados na base de dados
    /// </summary>
    /// <returns>Retorna a lista </returns>
    public List<DataDTO> GetAllData()
    {
        List<DataDTO> datas = new List<DataDTO>();

        using (var connection = DBHelp.DBConnection())
        {
            try
            {
                connection.Open();
                string table = "Data";
                string idDataCol = "idData";
                string idHardwareCol = "HardwareidHardware";
                string idDataTypeCol = "idDataType";
                string valueCol = "name";
                string registrationDateCol = "registrationDate";

                using (var command = new NpgsqlCommand($"SELECT \"{idDataCol}\",\"{idHardwareCol}\", \"{idDataTypeCol}\", \"{valueCol}\", \"{registrationDateCol}\" FROM \"{table}\"", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DataDTO data = new DataDTO()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal(idDataCol)),
                            IdDataType = reader.GetInt32(reader.GetOrdinal(idDataTypeCol)),
                            IdHardware = reader.GetInt32(reader.GetOrdinal(idHardwareCol)),
                            RegistrationDate = reader.GetDateTime(reader.GetOrdinal(registrationDateCol)),
                            Value = reader.GetString(reader.GetOrdinal(valueCol))
                        };
                        datas.Add(data);
                    }
                    reader.Close();
                }
                connection.Close();

                return datas;
            }
            catch 
            {
                throw new APIException(404, "Data record not found");
            }
        }
    }


    /// <summary>
    /// Função que converte as temperaturas em diferentes unidades de medidas (ºC, K, F)
    /// </summary>
    /// <param name="value">valor da temperatura a ser convertido</param>
    /// <param name="typeIn">tipo de entrada da temperatura</param>
    /// <param name="typeOut">tipo de saída da temperatura</param>
    /// <returns>Retorna o valor da temperatura</returns>
    public string ConverterTemperature(string valueIn, string typeIn, string typeOut)
    {
        //https://localhost:44324/Services/TemperatureConverterWS.asmx?WSDL

        string auxIn = typeIn.ToLower();
        string auxOut = typeOut.ToLower();
        float value = float.Parse(valueIn);
        TemperatureConverter.TemperatureConverterWSSoapClient function = new TemperatureConverterWSSoapClient(
                                                            new TemperatureConverterWSSoapClient.EndpointConfiguration());

        string valueT = string.Empty;

        if (auxIn[0].CompareTo('f') == 0)
        {
            if (auxOut[0].CompareTo('k') == 0)
            {
                valueT = function.FahrenheitToKelvin(value).ToString();

            }else if (auxOut[0].CompareTo('c') == 0)
            {
                valueT = function.FahrenheitToCelcius(value).ToString();
            }
        }
        else if ( auxIn[0].CompareTo('c') == 0)
        {
            if (auxOut[0].CompareTo('k') == 0)
            {
                valueT = function.CelsiusToKelvin(20).ToString();
            }
            else if (auxOut[0].CompareTo('f') == 0)
            {
                valueT =  function.CelsiusToFahrenheit(value).ToString();
            }
        }
        else if (auxIn[0].CompareTo('k') == 0)
        {
            if (auxOut[0].CompareTo('c') == 0)
            {
                valueT =  function.KelvinToCelsius(value).ToString();

            }
            else if (auxOut[0].CompareTo('f') == 0)
            {
                valueT = function.FahrenheitToCelcius(value).ToString();
            }
        }
        return valueT;
    }

    
    /// <summary>
    /// Função para inserir dados provenientes do Hardware na base de dados
    /// </summary>
    /// <param name="data">objeto Data</param>
    /// <returns>Retorna verdade ou falso</returns>
    /// <exception cref="Exception"></exception>
    public bool CreateData(DataDTO data)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Data";
                string idDataCol = "idData";
                string idHardwareCol = "HardwareidHardware";
                string idDataTypeCol = "idDataType";
                string valueCol = "value";
                string registrationDateCol = "registrationDate";

                string query = $"INSERT INTO public.\"{table}\"(\"{idDataTypeCol}\",\"{valueCol}\", \"{registrationDateCol}\") " +
                                $"VALUES(@IdDataType, @Value, @RegistrationDate)";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdDataType", data.IdDataType);
                command.Parameters.AddWithValue("@Value", data.Value);
                command.Parameters.AddWithValue("@RegistrationDate", data.RegistrationDate);
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
    /// Função para eliminar dados na base de dados
    /// </summary>
    /// <param name="idHardware">id do hardware</param>
    /// <returns>Retorna verdade ou falso</returns>
    /// <exception cref="Exception"></exception>
    public bool DeleteData(int idHardware)
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
            throw new Exception("Something went wrong when deleting the record Data");
        }
    }

    public void SaveData(DataDTO data)
    {
        try
        {
            using (var connection = DBHelp.DBConnection())
            {
                connection.Open();
                string table = "Data";
                string idDataCol = "idData";
                string hardwareIdHardwareCol = "HardwareidHardware";
                string idDataTypeCol = "idDataType";
                string valueCol = "value";
                string registrationDateCol = "registrationDate";
                string query = $"INSERT INTO public.\"{table}\" " +
                               $" (\"{hardwareIdHardwareCol}\", \"{idDataTypeCol}\", \"{valueCol}\", \"{registrationDateCol}\") VALUES " +
                               $" (@IdHardware, @IdDataType, @Value, @RegistrationDate);";

                Console.Write(query);
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdHardware", data.IdHardware);
                command.Parameters.AddWithValue("@IdDataType", data.IdDataType);
                command.Parameters.AddWithValue("@Value", data.Value);
                command.Parameters.AddWithValue("@RegistrationDate", data.RegistrationDate);
                if(command.ExecuteNonQuery() > 0)
                    Console.WriteLine("Success");
                else
                {
                    Console.WriteLine("Failure");
                }
                connection.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}