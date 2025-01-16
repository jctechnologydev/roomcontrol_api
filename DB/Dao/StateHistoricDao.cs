using Backend.Model;
using DAL.Dao;
using DAL.Model;
using Npgsql;

namespace DB.Dao;

public class StateHistoricDao : IStateHistoricDao
{
    private IStateDao _stateDao;
    
    public StateHistoricDao(IStateDao stateDao)
    {
        _stateDao = stateDao;
    }

    public void SetState(int idHardware, int idState)
    {
        StateDTO stateDto = _stateDao.GetState(idState);
        if (stateDto == null)
        {
            throw new APIException(404, "Não foi possivel encontrar o estado");
        }
        using (var connection = DBHelp.DBConnection())
        {
            connection.Open();
            string table = "StateHistoric";
            string registrationDateCol = "registrationDate";
            string hardwareIdHardwareCol = "HardwareidHardware";
            string stateIdStateCol = "StateidState";
            DateTime dateTime = DateTime.Now;
            
            using (var command = new NpgsqlCommand($"INSERT INTO \"{table}\" (\"{registrationDateCol}\", \"{hardwareIdHardwareCol}\", \"{stateIdStateCol}\") VALUES (@Date, @IdHardware, @IdState)", connection))
            {
                command.Parameters.AddWithValue("@Date", dateTime);
                command.Parameters.AddWithValue("@IdHardware", idHardware);
                command.Parameters.AddWithValue("@IdState", idState);
                int code = command.ExecuteNonQuery();
                if (code == 0)
                {
                    throw new APIException(code, "Erro query");
                }
            }
            connection.Close();
        }
    }
}