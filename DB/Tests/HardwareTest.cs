/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using NUnit.Framework;
using DAL.Dao;
using DAL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

/*namespace DB.Tests;
[TestClass]
public class HardwareTest
{
    [TestMethod]
    public void TestGetAll()
    {
        HardwareDao hardwareDao = new HardwareDao();
        HardwareDTO hardwareDTO = new HardwareDTO
        {
            Code = 1,
            IdHardwareType = 1,
            IdFuncionality = 2,
            Name = "Sensor Humidade"
        };
        Assert.Greater(hardwareDao.CreateHardware(hardwareDTO), 0);
    }

    [TestMethod]
    public void Sum()
    {
        int a = 2;
        Assert.IsTrue(a < 5, "Failed");
    }
}
*/