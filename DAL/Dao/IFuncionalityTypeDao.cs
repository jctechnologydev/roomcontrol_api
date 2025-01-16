/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using DAL.Model;

namespace DAL.Dao;

public interface IFuncionalityTypeDao
{
    public List<FuncionalityTypeDTO> GetAllFuncionality();
    public bool ExistsFuncionality(int idFuncionality);
    public bool Add(FuncionalityTypeDTO funcionalityType);
    public FuncionalityTypeDTO GetById(int idFuncionalityType);
}

