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
    public class Schedule
    {
        private int idSchedule;
        private int idDayOfWeekk;
        private string initialTime;
        private string duration;

        public int IdSchedule
        {
            get => idSchedule;
            set => idSchedule = value;
        }

        public int IdDayOfWeekk
        {
            get => idDayOfWeekk;
            set => idDayOfWeekk = value;
        }

        public string InitialTime
        {
            get => initialTime;
            set => initialTime = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Duration
        {
            get => duration;
            set => duration = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}