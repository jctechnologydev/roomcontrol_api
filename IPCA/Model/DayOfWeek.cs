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
    public class DayOfWeek
    {
        private int idDayOfWeek;
        private string name;

        public int IdDayOfWeek
        {
            get => idDayOfWeek;
            set => idDayOfWeek = value;
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}