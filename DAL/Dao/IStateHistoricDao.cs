namespace DAL.Dao;

public interface IStateHistoricDao
{
    public void SetState(int idHardware, int idState);
}