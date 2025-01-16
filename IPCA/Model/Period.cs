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
    public class Period
    {
        private int idPeriod;
        private string name;
        private string initialTime;
        private string finalTime;

        public int IdPeriod
        {
            get => idPeriod;
            set => idPeriod = value;
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string InitialTime
        {
            get => initialTime;
            set => initialTime = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string FinalTime
        {
            get => finalTime;
            set => finalTime = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}