using NUnit.Framework;
using DAL.Model;
using DAL.Dao;

namespace AllTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetAll()
        {
            HardwareDao hardwareDao = new HardwareDao();
            HardwareDTO hardwareDTO = new HardwareDTO
            {
                Id = 1,
                IdHardwareType = 1,
                IdFuncionality = 2,
                Name = "Sensor Humidade"
            };
            Assert.Greater(hardwareDao.CreateHardware(hardwareDTO), 0);
        }

        [Test]
        public void Sum()
        {
            int a = 2;
            Assert.IsTrue(a < 5, "Failed");
        }
    }
}