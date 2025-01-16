/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using AutoMapper;
using Backend.Model.HardwareCRUD;
using Backend.Model.Request;
using DAL.Model;
namespace Backend.Mapping;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<HardwareDTO, CreateHardware>().ReverseMap();
        CreateMap<HardwareDTO, UpdateHardware>().ReverseMap();
        CreateMap<HardwareDTO, DeleteHardware>().ReverseMap();

        CreateMap<InstallationHistoricDTO, CreateInstallationHistoric>().ReverseMap();

        CreateMap<AlertDTO, AlertEvent>().ReverseMap();


    }

}
    
