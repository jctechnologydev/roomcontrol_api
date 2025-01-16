using DB.Dao;
using NUnit.Framework;


namespace DB.Tests;

public class StateTest
{
    [Test]
    public void TestGetAll()
    {
        StateDao stateDao = new StateDao();
        
        Assert.IsTrue(stateDao.GetAllState().Any());
    }
}