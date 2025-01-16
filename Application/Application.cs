/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using DAL.Dao;
using DB.Dao;
using MQTT;
using MQTT.Interface;


namespace Application;

public class Application
{
    private static IStateDao _stateDao = null;
    private static IHardwareDao _hardwareDao = null; 
    private static IAlertDao _alertDao = null;
    private static IFuncionalityTypeDao _funcionalityTypeDao = null;
    private static IHardwareTypeDao _hardwareTypeDao = null;
    private static IInstallationHistoricDao _installationHistoricDao = null;
    private static IDataDao _dataDao = null;
    private static IDataTypeDao _dataTypeDao = null;
    private static IMqtt _mqtt = null;
    private static IStateHistoricDao _stateHistoricDao = null;

    public static IStateDao GetStateDao()
    {
        if (_stateDao == null)
            _stateDao = new StateDao();

        return _stateDao;
    }

    public static IStateHistoricDao GetStateHistoric()
    {
        if (_stateHistoricDao == null)
            _stateHistoricDao = new StateHistoricDao(GetStateDao());
        
        return _stateHistoricDao;
    }

    public static IHardwareDao GetHardwareDao()
    {
        if (_hardwareDao == null)
            _hardwareDao = new HardwareDao(GetHardwareTypeDao(), GetFuncionalityTypeDao(), GetAlertDao(), GetInstallationHistoricDao(), GetDataDao());

        return _hardwareDao;
    }


    public static IAlertDao GetAlertDao()
    {

        {
            if (_alertDao == null) 
                _alertDao = new AlertDao(GetHardwareTypeDao(), GetInstallationHistoricDao());

            return _alertDao;
        }

    }

    public static IFuncionalityTypeDao GetFuncionalityTypeDao()
    {
        {
            if (_funcionalityTypeDao == null)
                _funcionalityTypeDao = new FuncionalityTypeDao();

            return _funcionalityTypeDao;
        }

    }

    public static IHardwareTypeDao GetHardwareTypeDao()
    {
        {
            if (_hardwareTypeDao == null)
                _hardwareTypeDao = new HardwareTypeDao();

            return _hardwareTypeDao;
        }

    }

    public static IInstallationHistoricDao GetInstallationHistoricDao()
    {
        if (_installationHistoricDao == null)
                _installationHistoricDao = new InstallationHistoricDao();

        return _installationHistoricDao;
    }

    public static IDataTypeDao GetDataTypeDao()
    {
        {
            if (_dataTypeDao == null)
                _dataTypeDao = new DataTypeDao();

            return _dataTypeDao;
        }

    }

    public static IDataDao GetDataDao()
    {

        {
            if (_dataDao == null)
                _dataDao = new DataDao(GetDataTypeDao());

            return _dataDao;
        }

    }




    public static IMqtt Mqtt()
    {
        if (_mqtt == null)
            _mqtt = new Client();

        return _mqtt;
    }

 

}