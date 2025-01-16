/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace IPCA.Model
{
    public class Course
    {
        private int idCourse;
        private int idSchool;
        private int idPeriod;
        private string? name;

        public int IdCourse
        {
            get => idCourse;
            set => idCourse = value;
        }

        public int IdSchool
        {
            get => idSchool;
            set => idSchool = value;
        }

        public int IdPeriod
        {
            get => idPeriod;
            set => idPeriod = value;
        }

        public string? Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}